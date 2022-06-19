using DogFacts.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DogFacts.Forms
{
    public partial class ConfigForm : Form
    {
        public ConfigForm()
        {
            InitializeComponent();

            Load += OnLoad;

            btnInputSearch.Click += OnInputSearchClick;
            btnOutputSearch.Click += OnOutputSearchClick;
            btnSave.Click += OnSaveClick;
        }

        private void OnLoad(object? sender, EventArgs e)
        {
            txtConnectionString.Text = Settings.Default.ConnectionString;
            txtQueueName.Text = Settings.Default.QueueName;
            txtEndpoint.Text = Settings.Default.Endpoint;
            txtInput.Text = Settings.Default.InputFolder;
            txtOutput.Text = Settings.Default.OutputFolder;
        }

        private void OnInputSearchClick(object? sender, EventArgs e)
        {
            txtInput.Text = GetFolder("Pasta de entrada");
        }

        private void OnOutputSearchClick(object? sender, EventArgs e)
        {
            txtOutput.Text = GetFolder("Pasta de saída");
        }

        private void OnSaveClick(object? sender, EventArgs e)
        {
            Settings.Default.ConnectionString = txtConnectionString.Text;
            Settings.Default.QueueName = txtQueueName.Text;
            Settings.Default.Endpoint = txtEndpoint.Text;
            Settings.Default.InputFolder = txtInput.Text;
            Settings.Default.OutputFolder = txtOutput.Text;
            Settings.Default.Save();

            DialogResult = DialogResult.OK;
            Close();
        }

        private string GetFolder(string title)
        {
            var dialog = new FolderBrowserDialog
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                Description = title,
                ShowNewFolderButton = true,
                UseDescriptionForTitle = true
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                return dialog.SelectedPath;
            }

            return string.Empty;
        }
    }
}
