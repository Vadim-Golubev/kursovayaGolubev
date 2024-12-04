
namespace курсовая_работа
{
    partial class ImportExport
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.import = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.Export = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // import
            // 
            this.import.Location = new System.Drawing.Point(36, 12);
            this.import.Name = "import";
            this.import.Size = new System.Drawing.Size(135, 52);
            this.import.TabIndex = 0;
            this.import.Text = "Импорт";
            this.import.UseVisualStyleBackColor = true;
            this.import.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(36, 298);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(135, 52);
            this.button3.TabIndex = 2;
            this.button3.Text = "Главное меню";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Export
            // 
            this.Export.Location = new System.Drawing.Point(36, 70);
            this.Export.Name = "Export";
            this.Export.Size = new System.Drawing.Size(135, 52);
            this.Export.TabIndex = 1;
            this.Export.Text = "Восстановить структуру";
            this.Export.UseVisualStyleBackColor = true;
            this.Export.Click += new System.EventHandler(this.button2_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "client",
            "games",
            "rooms",
            "users",
            "session"});
            this.comboBox1.Location = new System.Drawing.Point(36, 128);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(135, 21);
            this.comboBox1.TabIndex = 3;
            // 
            // ImportExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(217, 362);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.Export);
            this.Controls.Add(this.import);
            this.Name = "ImportExport";
            this.Text = "ImportExport";
            this.Load += new System.EventHandler(this.ImportExport_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button import;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button Export;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}