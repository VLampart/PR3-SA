using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lr03_Lampart
{
    public partial class ButtonsControl : UserControl
    {
        public enum OperationType
        {
            Word,
            Excel
        }
        private MainForm mainForm;
        private OperationType operationType;
        private string dllPath = "D:\\KHAI\\.NET\\Lr03_Lampart\\ClassLibrary\\bin\\Debug\\net8.0\\ClassLibrary.dll";

        public MainForm MainForm { get => mainForm; set => mainForm = value; }
        public OperationType OType { get => operationType; set => operationType = value; }

        public ButtonsControl()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            switch (operationType)
            {
                case OperationType.Word:
                    SaveToWord();
                    break;
                case OperationType.Excel:
                    SaveToExcel();
                    break;
            }
        }

        private void SaveToWord()
        {
            try
            {
                string filePath = Path.Combine(Environment.CurrentDirectory, "temp", "newreport.docx");

                // Завантаження DLL
                Assembly assembly = Assembly.LoadFrom(dllPath);
                Type wordType = assembly.GetType("ClassLibrary.WordClass");
                object wordInstance = Activator.CreateInstance(wordType);
                MethodInfo exportMethod = wordType.GetMethod("ExportToWord");

                // Зчитування тексту з RichTextBox та експорт в Word
                string textToExport = mainForm.richTextBox.Text;
                exportMethod.Invoke(wordInstance, new object[] { textToExport, filePath });


                MessageBox.Show("Експорт завершено!", "Export Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Export Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveToExcel()
        {
            try
            {
                string filePath = Path.Combine(Environment.CurrentDirectory, "temp", "newreport.xlsx");
                
                // Створення двовимірного масиву з даних DataGridView
                int rowCount = mainForm.dataGrid.Rows.Count;
                int colCount = mainForm.dataGrid.Columns.Count;
                string[,] data = new string[rowCount, colCount];

                // Заповнення масиву даними з DataGridView
                for (int i = 0; i < rowCount; i++)
                {
                    for (int j = 0; j < colCount; j++)
                    {
                        data[i, j] = mainForm.dataGrid.Rows[i].Cells[j].Value?.ToString();
                    }
                }

                // Завантаження DLL
                Assembly assembly = Assembly.LoadFrom(dllPath);
                Type excelType = assembly.GetType("ClassLibrary.ExcelClass");
                object excelInstance = Activator.CreateInstance(excelType);
                MethodInfo exportMethod = excelType.GetMethod("ExportToExcel");

                // Експорт двовимірного масиву в Excel
                exportMethod.Invoke(excelInstance, new object[] { data, filePath });
                
                MessageBox.Show("Експорт завершено!", "Export Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Export Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDataFromWord(string filePath)
        {
            try
            {
                mainForm.richTextBox.Clear();

                Assembly assembly = Assembly.LoadFrom(dllPath);
                Type wordType = assembly.GetType("ClassLibrary.WordClass");
                object wordInstance = Activator.CreateInstance(wordType);
                MethodInfo importMethod = wordType.GetMethod("ImportFromWord");

                // Отримання тексту з Word
                string text = (string)importMethod.Invoke(wordInstance, new object[] { filePath });

                // Відображення тексту у RichTextBox
                mainForm.richTextBox.Text = text;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка під час завантаження даних: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDataFromExcel(string filePath)
        {
            try
            {
                RemoveAllColumns(mainForm.dataGrid);

                Assembly assembly = Assembly.LoadFrom(dllPath);
                Type excelType = assembly.GetType("ClassLibrary.ExcelClass");
                object excelInstance = Activator.CreateInstance(excelType);
                MethodInfo importMethod = excelType.GetMethod("ImportFromExcel");

                // Отримання даних з Excel і завантаження їх до DataGridView
                DataTable dt = (DataTable)importMethod.Invoke(excelInstance, new object[] { filePath });
                mainForm.dataGrid.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка під час завантаження даних: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            switch (operationType)
            {
                case OperationType.Word:
                    {
                        openFileDialog.Filter = "Word files (*.docx)|*.docx|All files (*.*)|*.*";
                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            string filePath = openFileDialog.FileName;
                            LoadDataFromWord(filePath);
                        }
                        break;
                    }
                case OperationType.Excel:
                    {
                        openFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";

                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            string filePath = openFileDialog.FileName;
                            LoadDataFromExcel(filePath);
                        }
                        break;
                    }
            }
        }

        private void ClearDataGridView(DataGridView dataGridView)
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Value = string.Empty;
                }
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            switch (operationType)
            {
                case OperationType.Word:
                    mainForm.richTextBox.Clear();
                    break;
                case OperationType.Excel:
                    RemoveAllColumns(mainForm.dataGrid);
                    break;
            }
        }

        private void RemoveAllColumns(DataGridView dataGridView)
        {
            while (dataGridView.Columns.Count > 0)
            {
                dataGridView.Columns.RemoveAt(0);
            }
        }
    }
}
