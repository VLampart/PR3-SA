namespace Lr03_Lampart
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tab = new TabControl();
            textPage = new TabPage();
            richTextBox = new RichTextBox();
            tablePage = new TabPage();
            dataGrid = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            buttonsControl = new ButtonsControl();
            openFileDialog = new OpenFileDialog();
            tab.SuspendLayout();
            textPage.SuspendLayout();
            tablePage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGrid).BeginInit();
            SuspendLayout();
            // 
            // tab
            // 
            tab.Controls.Add(textPage);
            tab.Controls.Add(tablePage);
            tab.Dock = DockStyle.Left;
            tab.Location = new Point(0, 0);
            tab.Name = "tab";
            tab.SelectedIndex = 0;
            tab.Size = new Size(613, 450);
            tab.TabIndex = 0;
            tab.SelectedIndexChanged += tab_SelectedIndexChanged;
            // 
            // textPage
            // 
            textPage.Controls.Add(richTextBox);
            textPage.Location = new Point(4, 24);
            textPage.Name = "textPage";
            textPage.Padding = new Padding(3);
            textPage.Size = new Size(605, 422);
            textPage.TabIndex = 0;
            textPage.Text = "Text";
            textPage.UseVisualStyleBackColor = true;
            // 
            // richTextBox
            // 
            richTextBox.Dock = DockStyle.Left;
            richTextBox.Location = new Point(3, 3);
            richTextBox.Name = "richTextBox";
            richTextBox.Size = new Size(594, 416);
            richTextBox.TabIndex = 0;
            richTextBox.Text = "";
            // 
            // tablePage
            // 
            tablePage.Controls.Add(dataGrid);
            tablePage.Location = new Point(4, 24);
            tablePage.Name = "tablePage";
            tablePage.Padding = new Padding(3);
            tablePage.Size = new Size(605, 422);
            tablePage.TabIndex = 1;
            tablePage.Text = "Table";
            tablePage.UseVisualStyleBackColor = true;
            // 
            // dataGrid
            // 
            dataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGrid.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column5 });
            dataGrid.Dock = DockStyle.Left;
            dataGrid.Location = new Point(3, 3);
            dataGrid.Name = "dataGrid";
            dataGrid.Size = new Size(594, 416);
            dataGrid.TabIndex = 0;
            // 
            // Column1
            // 
            Column1.HeaderText = "Column1";
            Column1.Name = "Column1";
            // 
            // Column2
            // 
            Column2.HeaderText = "Column2";
            Column2.Name = "Column2";
            // 
            // Column3
            // 
            Column3.HeaderText = "Column3";
            Column3.Name = "Column3";
            // 
            // Column4
            // 
            Column4.HeaderText = "Column4";
            Column4.Name = "Column4";
            // 
            // Column5
            // 
            Column5.HeaderText = "Column5";
            Column5.Name = "Column5";
            // 
            // buttonsControl
            // 
            buttonsControl.BorderStyle = BorderStyle.FixedSingle;
            buttonsControl.Location = new Point(615, 24);
            buttonsControl.MainForm = null;
            buttonsControl.Name = "buttonsControl";
            buttonsControl.OType = ButtonsControl.OperationType.Word;
            buttonsControl.Size = new Size(185, 134);
            buttonsControl.TabIndex = 1;
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "openFileDialog";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(807, 450);
            Controls.Add(buttonsControl);
            Controls.Add(tab);
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PR03_Lampart";
            tab.ResumeLayout(false);
            textPage.ResumeLayout(false);
            tablePage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        public TabControl tab;
        public TabPage textPage;
        public RichTextBox richTextBox;
        public TabPage tablePage;
        public DataGridView dataGrid;
        private ButtonsControl buttonsControl;
        private OpenFileDialog openFileDialog;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
    }
}
