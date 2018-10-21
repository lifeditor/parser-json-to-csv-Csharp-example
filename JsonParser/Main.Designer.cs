namespace JsonParser
{
    partial class frmMain
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
            this.buttonDownload = new System.Windows.Forms.Button();
            this.buttonParse = new System.Windows.Forms.Button();
            this.messageText = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.urlText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonDownload
            // 
            this.buttonDownload.Location = new System.Drawing.Point(29, 101);
            this.buttonDownload.Name = "buttonDownload";
            this.buttonDownload.Size = new System.Drawing.Size(163, 44);
            this.buttonDownload.TabIndex = 0;
            this.buttonDownload.Text = "DOWNLOAD JSON";
            this.buttonDownload.UseVisualStyleBackColor = true;
            this.buttonDownload.Click += new System.EventHandler(this.buttonDownload_Click);
            // 
            // buttonParse
            // 
            this.buttonParse.Location = new System.Drawing.Point(29, 24);
            this.buttonParse.Name = "buttonParse";
            this.buttonParse.Size = new System.Drawing.Size(163, 42);
            this.buttonParse.TabIndex = 1;
            this.buttonParse.Text = "JSON2CSV CONVERT";
            this.buttonParse.UseVisualStyleBackColor = true;
            this.buttonParse.Click += new System.EventHandler(this.buttonParse_Click);
            // 
            // messageText
            // 
            this.messageText.Location = new System.Drawing.Point(26, 168);
            this.messageText.Name = "messageText";
            this.messageText.Size = new System.Drawing.Size(656, 23);
            this.messageText.TabIndex = 2;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(29, 194);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(653, 23);
            this.progressBar.TabIndex = 3;
            // 
            // urlText
            // 
            this.urlText.AutoSize = true;
            this.urlText.Location = new System.Drawing.Point(212, 117);
            this.urlText.Name = "urlText";
            this.urlText.Size = new System.Drawing.Size(29, 13);
            this.urlText.TabIndex = 5;
            this.urlText.Text = "URL";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 237);
            this.Controls.Add(this.urlText);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.messageText);
            this.Controls.Add(this.buttonParse);
            this.Controls.Add(this.buttonDownload);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "rub90 JSON2CSV Converter";
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonDownload;
        private System.Windows.Forms.Button buttonParse;
        private System.Windows.Forms.Label messageText;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label urlText;
    }
}

