using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace ClassLibrary
{
    internal class ExcelClass
    {
        public void ExportToExcel(string[,] data, string filePath)
        {
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workbook = excelApp.Workbooks.Add();
            Excel.Worksheet worksheet = workbook.ActiveSheet;

            try
            {
                int rowCount = data.GetLength(0);
                int colCount = data.GetLength(1);

                for (int i = 0; i < colCount; i++)
                {
                    worksheet.Cells[1, i + 1] = "Column " + (i + 1);
                }

                for (int i = 0; i < rowCount; i++)
                {
                    for (int j = 0; j < colCount; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = data[i, j];
                    }
                }

                workbook.SaveAs(filePath);
            }
            catch (Exception ex)
            {
                throw new Exception("Error writing Excel document", ex);
            }
            finally
            {
                workbook.Close();
                Marshal.FinalReleaseComObject(worksheet);
                Marshal.FinalReleaseComObject(workbook);
                excelApp.Quit();
                Marshal.FinalReleaseComObject(excelApp);

                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

        public DataTable ImportFromExcel(string filePath)
        {
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workbook = excelApp.Workbooks.Open(filePath);
            Excel.Worksheet worksheet = workbook.Sheets[1];
            Excel.Range range = worksheet.UsedRange;

            DataTable dt = new DataTable();

            try
            {
                for (int i = 1; i <= range.Columns.Count; i++)
                {
                    dt.Columns.Add((range.Cells[1, i] as Excel.Range).Value2.ToString());
                }
                for (int row = 2; row <= range.Rows.Count; row++)
                {
                    DataRow dr = dt.NewRow();
                    for (int col = 1; col <= range.Columns.Count; col++)
                    {
                        dr[col - 1] = (range.Cells[row, col] as Excel.Range).Value2.ToString();
                    }
                    dt.Rows.Add(dr);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error reading Excel document", ex);
            }
            finally
            {
                workbook.Close();
                Marshal.FinalReleaseComObject(worksheet);
                Marshal.FinalReleaseComObject(workbook);
                excelApp.Quit();
                Marshal.FinalReleaseComObject(excelApp);

                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            return dt;
        }
    }
}
