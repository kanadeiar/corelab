namespace WinFormsApp1
{
    partial class Form1
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBoxStart = new TextBox();
            textBoxEnd = new TextBox();
            textBoxLength = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(36, 41);
            label1.Name = "label1";
            label1.Size = new Size(49, 15);
            label1.TabIndex = 0;
            label1.Text = "Начало";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(36, 105);
            label2.Name = "label2";
            label2.Size = new Size(41, 15);
            label2.TabIndex = 0;
            label2.Text = "Конец";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(36, 172);
            label3.Name = "label3";
            label3.Size = new Size(49, 15);
            label3.TabIndex = 0;
            label3.Text = "Длинна";
            // 
            // textBoxStart
            // 
            textBoxStart.Location = new Point(143, 38);
            textBoxStart.Name = "textBoxStart";
            textBoxStart.Size = new Size(213, 23);
            textBoxStart.TabIndex = 1;
            textBoxStart.Leave += textBox_Leave;
            // 
            // textBoxEnd
            // 
            textBoxEnd.Location = new Point(143, 102);
            textBoxEnd.Name = "textBoxEnd";
            textBoxEnd.Size = new Size(213, 23);
            textBoxEnd.TabIndex = 1;
            textBoxEnd.Leave += textBox_Leave;
            // 
            // textBoxLength
            // 
            textBoxLength.Location = new Point(143, 169);
            textBoxLength.Name = "textBoxLength";
            textBoxLength.Size = new Size(213, 23);
            textBoxLength.TabIndex = 1;
            textBoxLength.Leave += textBox_Leave;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(531, 293);
            Controls.Add(textBoxLength);
            Controls.Add(textBoxEnd);
            Controls.Add(textBoxStart);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Рефакторинг";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBoxStart;
        private TextBox textBoxEnd;
        private TextBox textBoxLength;
    }
}
