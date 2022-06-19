namespace DogFacts.Forms
{
    partial class ConfigForm
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
            this.txtConnectionString = new System.Windows.Forms.TextBox();
            this.txtQueueName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.line = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.txtEndpoint = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.btnInputSearch = new System.Windows.Forms.Button();
            this.btnOutputSearch = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtConnectionString
            // 
            this.txtConnectionString.Location = new System.Drawing.Point(12, 36);
            this.txtConnectionString.Name = "txtConnectionString";
            this.txtConnectionString.Size = new System.Drawing.Size(335, 23);
            this.txtConnectionString.TabIndex = 0;
            // 
            // txtQueueName
            // 
            this.txtQueueName.Location = new System.Drawing.Point(12, 87);
            this.txtQueueName.Name = "txtQueueName";
            this.txtQueueName.Size = new System.Drawing.Size(335, 23);
            this.txtQueueName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Cadeia de Conexão:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nome da Fila:";
            // 
            // line
            // 
            this.line.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.line.Location = new System.Drawing.Point(12, 129);
            this.line.Name = "line";
            this.line.Size = new System.Drawing.Size(335, 1);
            this.line.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 199);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Pasta de entrada:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "Endpoint:";
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(12, 217);
            this.txtInput.Name = "txtInput";
            this.txtInput.ReadOnly = true;
            this.txtInput.Size = new System.Drawing.Size(254, 23);
            this.txtInput.TabIndex = 6;
            // 
            // txtEndpoint
            // 
            this.txtEndpoint.Location = new System.Drawing.Point(12, 166);
            this.txtEndpoint.Name = "txtEndpoint";
            this.txtEndpoint.Size = new System.Drawing.Size(335, 23);
            this.txtEndpoint.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 254);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "Pasta de saída:";
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(12, 272);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.Size = new System.Drawing.Size(254, 23);
            this.txtOutput.TabIndex = 9;
            // 
            // btnInputSearch
            // 
            this.btnInputSearch.Location = new System.Drawing.Point(272, 217);
            this.btnInputSearch.Name = "btnInputSearch";
            this.btnInputSearch.Size = new System.Drawing.Size(75, 23);
            this.btnInputSearch.TabIndex = 11;
            this.btnInputSearch.Text = "Procurar";
            this.btnInputSearch.UseVisualStyleBackColor = true;
            // 
            // btnOutputSearch
            // 
            this.btnOutputSearch.Location = new System.Drawing.Point(272, 271);
            this.btnOutputSearch.Name = "btnOutputSearch";
            this.btnOutputSearch.Size = new System.Drawing.Size(75, 23);
            this.btnOutputSearch.TabIndex = 12;
            this.btnOutputSearch.Text = "Procurar";
            this.btnOutputSearch.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(12, 313);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(335, 1);
            this.label3.TabIndex = 13;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(123, 329);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(112, 23);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Salvar e Sair";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // ConfigForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 364);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnOutputSearch);
            this.Controls.Add(this.btnInputSearch);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.txtEndpoint);
            this.Controls.Add(this.line);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtQueueName);
            this.Controls.Add(this.txtConnectionString);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuração";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txtConnectionString;
        private TextBox txtQueueName;
        private Label label1;
        private Label label2;
        private Label line;
        private Label label4;
        private Label label5;
        private TextBox txtInput;
        private TextBox txtEndpoint;
        private Label label6;
        private TextBox txtOutput;
        private Button btnInputSearch;
        private Button btnOutputSearch;
        private Label label3;
        private Button btnSave;
    }
}