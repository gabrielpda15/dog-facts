namespace DogFacts.Forms
{
    partial class MainForm
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
            this.btnConfig = new System.Windows.Forms.Button();
            this.log = new System.Windows.Forms.ListBox();
            this.fileList = new System.Windows.Forms.ListBox();
            this.btnProcess = new System.Windows.Forms.Button();
            this.btnToggle = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnConfig
            // 
            this.btnConfig.Location = new System.Drawing.Point(260, 333);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(112, 23);
            this.btnConfig.TabIndex = 1;
            this.btnConfig.Text = "Configurações";
            this.btnConfig.UseVisualStyleBackColor = true;
            // 
            // log
            // 
            this.log.FormattingEnabled = true;
            this.log.ItemHeight = 15;
            this.log.Location = new System.Drawing.Point(12, 12);
            this.log.Name = "log";
            this.log.Size = new System.Drawing.Size(360, 199);
            this.log.TabIndex = 3;
            // 
            // fileList
            // 
            this.fileList.FormattingEnabled = true;
            this.fileList.ItemHeight = 15;
            this.fileList.Location = new System.Drawing.Point(12, 217);
            this.fileList.Name = "fileList";
            this.fileList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.fileList.Size = new System.Drawing.Size(242, 139);
            this.fileList.TabIndex = 4;
            // 
            // btnProcess
            // 
            this.btnProcess.Enabled = false;
            this.btnProcess.Location = new System.Drawing.Point(260, 217);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(112, 81);
            this.btnProcess.TabIndex = 5;
            this.btnProcess.Text = "Processar arquivos selecionados";
            this.btnProcess.UseVisualStyleBackColor = true;
            // 
            // btnToggle
            // 
            this.btnToggle.Location = new System.Drawing.Point(260, 304);
            this.btnToggle.Name = "btnToggle";
            this.btnToggle.Size = new System.Drawing.Size(112, 23);
            this.btnToggle.TabIndex = 6;
            this.btnToggle.Text = "Pausar";
            this.btnToggle.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 368);
            this.Controls.Add(this.btnToggle);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.fileList);
            this.Controls.Add(this.log);
            this.Controls.Add(this.btnConfig);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dog Facts";
            this.ResumeLayout(false);

        }

        #endregion
        private Button btnConfig;
        private ListBox log;
        private ListBox fileList;
        private Button btnProcess;
        private Button btnToggle;
    }
}