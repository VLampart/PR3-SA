namespace Lr03_Lampart
{
    partial class ButtonsControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            loadButton = new Button();
            clearButton = new Button();
            saveButton = new Button();
            SuspendLayout();
            // 
            // loadButton
            // 
            loadButton.BackColor = SystemColors.Highlight;
            loadButton.Location = new Point(50, 91);
            loadButton.Name = "loadButton";
            loadButton.Size = new Size(86, 38);
            loadButton.TabIndex = 6;
            loadButton.Text = "Завантажити";
            loadButton.UseVisualStyleBackColor = false;
            loadButton.Click += loadButton_Click;
            // 
            // clearButton
            // 
            clearButton.BackColor = SystemColors.Highlight;
            clearButton.Location = new Point(50, 47);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(86, 38);
            clearButton.TabIndex = 5;
            clearButton.Text = "Очистити";
            clearButton.UseVisualStyleBackColor = false;
            clearButton.Click += clearButton_Click;
            // 
            // saveButton
            // 
            saveButton.BackColor = SystemColors.Highlight;
            saveButton.Location = new Point(50, 3);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(86, 38);
            saveButton.TabIndex = 4;
            saveButton.Text = "Зберегти";
            saveButton.UseVisualStyleBackColor = false;
            saveButton.Click += saveButton_Click;
            // 
            // ButtonsControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(loadButton);
            Controls.Add(clearButton);
            Controls.Add(saveButton);
            Name = "ButtonsControl";
            Size = new Size(185, 134);
            ResumeLayout(false);
        }

        #endregion

        private Button loadButton;
        private Button clearButton;
        private Button saveButton;
    }
}
