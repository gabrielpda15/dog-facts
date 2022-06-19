using DogFacts.Properties;
using DogFacts.Services;
using Newtonsoft.Json;
using System.Data;

namespace DogFacts.Forms
{
    public partial class MainForm : Form
    {
        private const string TOGGLE_TEXT_PAUSE = "Pausar";
        private const string TOGGLE_TEXT_RESUME = "Continuar";

        private AzureService AzureService { get; set; }
        private ExcelService ExcelService { get; set; }
        private DogFactService DogFactService { get; set; }

        public MainForm()
        {
            InitializeComponent();

            AzureService = new AzureService();
            AzureService.ProcessMessageAsync += OnProcessMessageAsync;
            AzureService.ProcessErrorAsync += OnProcessErrorAsync;

            ExcelService = new ExcelService();

            DogFactService = new DogFactService();

            Load += OnLoad;
            FormClosing += OnFormClosing;
            btnConfig.Click += OnConfigClick;
            btnProcess.Click += OnProcessClick;
            btnToggle.Click += OnToggleClick;
            fileList.SelectedValueChanged += FileListSelectedValueChanged;
        }

        private async void OnFormClosing(object? sender, FormClosingEventArgs e)
        {
            await AzureService.StopProcessingAsync();
            AzureService.Dispose();
            ExcelService.Dispose();
            DogFactService.Dispose();
        }

        private async void OnLoad(object? sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Settings.Default.ConnectionString) ||
                string.IsNullOrEmpty(Settings.Default.QueueName))
            {
                var configForm = new ConfigForm();
                if (configForm.ShowDialog() != DialogResult.OK) return;
            }

            AzureService.Refresh();
            await AzureService.StartProcessingAsync();

            LoadFilesComboBox();
        }

        private async Task OnProcessMessageAsync(Azure.Messaging.ServiceBus.ProcessMessageEventArgs args)
        {
            Log($"Recebendo mensagem de id: {args.Message.MessageId}");

            var body = args.Message.Body.ToString();
            var obj = JsonConvert.DeserializeObject<IDictionary<string, IList<IList<string>>>>(body);

            if (obj == null)
            {
                Log($"Mensagem contem erros e foi abandonada.");
                await args.AbandonMessageAsync(args.Message);
                return;
            }

            Log($"Processando mensagem...");

            foreach (var key in obj.Keys)
            {
                var values = obj[key];

                var folder = Settings.Default.OutputFolder;
                if (folder.StartsWith(".\\")) folder = folder[2..];

                ExcelService.SaveDogFacts(values, Path.Combine(folder, $"{key}.xlsx"));
            }

            await args.CompleteMessageAsync(args.Message);

            Log($"Processamento finalizado com sucesso!");
        }

        private Task OnProcessErrorAsync(Azure.Messaging.ServiceBus.ProcessErrorEventArgs args)
        {
            log.Items.Add(args.Exception.ToString());
            return Task.CompletedTask;
        }

        private void OnConfigClick(object? sender, EventArgs e)
        {
            var configForm = new ConfigForm();
            if (configForm.ShowDialog() == DialogResult.OK)
            {
                AzureService.Refresh();

                LoadFilesComboBox();
            }
        }

        private async void OnProcessClick(object? sender, EventArgs e)
        {
            var folder = Settings.Default.InputFolder;
            if (folder.StartsWith(".\\")) folder = folder[2..];

            var result = new Dictionary<string, IList<IList<string>>>();

            Log("Lendo arquivos selecionados...");

            foreach (string item in fileList.SelectedItems)
            {
                result.Add(item, new List<IList<string>>());

                var values = ExcelService.ReadCells<int>(Path.Combine(folder, $"{item}.xlsx"), "A:A");                
                foreach (var value in values)
                {
                    var facts = await DogFactService.Get(value);
                    if (facts?.Facts != null)
                    {
                        result[item].Add(facts.Facts);
                    }
                }
            }

            Log("Enviando para a fila...");
            await AzureService.AddMessageAsync(result);
            Log($"Enviado para fila com sucesso!");
        }

        private async void OnToggleClick(object? sender, EventArgs e)
        {
            if (btnToggle.Text == TOGGLE_TEXT_PAUSE)
            {
                await AzureService.StopProcessingAsync();
                btnToggle.Text = TOGGLE_TEXT_RESUME;
            }
            else
            {
                await AzureService.StartProcessingAsync();
                btnToggle.Text = TOGGLE_TEXT_PAUSE;
            }
        }

        private void FileListSelectedValueChanged(object? sender, EventArgs e)
        {
            if (fileList.SelectedItems.Count > 0)
            {
                btnProcess.Enabled = true;
            } 
            else
            {
                btnProcess.Enabled = false;
            }
        }

        private void Log(string message)
        {
            if (log.InvokeRequired)
            {
                void safeWrite() { Log(message); }
                log.Invoke(safeWrite);
            }
            else
            {
                log.Items.Add(message);
            }
        }

        private void LoadFilesComboBox()
        {
            var folder = Settings.Default.InputFolder;
            if (folder.StartsWith(".\\")) folder = folder[2..];
            if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);

            fileList.Items.Clear();
            var files = Directory.GetFiles(folder, "*.xlsx");
            files = files.Select(x => Path.GetFileNameWithoutExtension(x)).ToArray();
            fileList.Items.AddRange(files);
        }
    }
}
