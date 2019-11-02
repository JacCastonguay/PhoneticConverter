namespace PhoneticTranslator
{
    partial class Form1
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
            this.BTConvert = new System.Windows.Forms.Button();
            this.TBPhrase = new System.Windows.Forms.TextBox();
            this.TBResults = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // BTConvert
            // 
            this.BTConvert.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTConvert.Location = new System.Drawing.Point(478, 309);
            this.BTConvert.Name = "BTConvert";
            this.BTConvert.Size = new System.Drawing.Size(183, 56);
            this.BTConvert.TabIndex = 0;
            this.BTConvert.Text = "Convert";
            this.BTConvert.UseVisualStyleBackColor = true;
            this.BTConvert.Click += new System.EventHandler(this.ConvertButton_Click);
            // 
            // TBPhrase
            // 
            this.TBPhrase.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBPhrase.Location = new System.Drawing.Point(235, 51);
            this.TBPhrase.Multiline = true;
            this.TBPhrase.Name = "TBPhrase";
            this.TBPhrase.Size = new System.Drawing.Size(668, 200);
            this.TBPhrase.TabIndex = 1;
            // 
            // TBResults
            // 
            this.TBResults.Location = new System.Drawing.Point(235, 425);
            this.TBResults.Multiline = true;
            this.TBResults.Name = "TBResults";
            this.TBResults.ReadOnly = true;
            this.TBResults.Size = new System.Drawing.Size(668, 200);
            this.TBResults.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1130, 687);
            this.Controls.Add(this.TBResults);
            this.Controls.Add(this.TBPhrase);
            this.Controls.Add(this.BTConvert);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTConvert;
        private System.Windows.Forms.TextBox TBPhrase;
        private System.Windows.Forms.TextBox TBResults;
    }
}

