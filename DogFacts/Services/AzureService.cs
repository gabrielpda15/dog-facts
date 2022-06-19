using Azure.Messaging.ServiceBus;
using DogFacts.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogFacts.Services
{
    public class AzureService : BaseService
    {
        private ServiceBusClient? Client { get; set; }
        private ServiceBusSender? Sender { get; set; }
        private ServiceBusProcessor? Processor { get; set; }

        public event Func<ProcessMessageEventArgs, Task>? ProcessMessageAsync;
        public event Func<ProcessErrorEventArgs, Task>? ProcessErrorAsync;

        public AzureService() : base() { }

        public void Refresh()
        {
            Dispose(true);

            Client = new ServiceBusClient(Settings.Default.ConnectionString);
            Sender = Client.CreateSender(Settings.Default.QueueName);
            Processor = Client.CreateProcessor(Settings.Default.QueueName, new ServiceBusProcessorOptions());

            Processor.ProcessMessageAsync += async (e) => { if (ProcessMessageAsync != null) await ProcessMessageAsync.Invoke(e); };
            Processor.ProcessErrorAsync += async (e) => { if (ProcessErrorAsync != null) await ProcessErrorAsync.Invoke(e); };

            _disposed = false;
        }

        public async Task AddMessageAsync<T>(T obj, CancellationToken ct = default)
        {
            if (Sender != null)
            {
                using ServiceBusMessageBatch messageBatch = await Sender.CreateMessageBatchAsync(ct);
                if (!messageBatch.TryAddMessage(new ServiceBusMessage(JsonConvert.SerializeObject(obj))))
                {
                    throw new Exception("A mensagem é muito grande para caber");
                }

                await Sender.SendMessagesAsync(messageBatch, ct);
            }            
        }

        public async Task StartProcessingAsync(CancellationToken ct = default)
        {
            if (Processor != null)
                await Processor.StartProcessingAsync(ct);
        }

        public async Task StopProcessingAsync(CancellationToken ct = default)
        {
            if (Processor != null)
                await Processor.StopProcessingAsync(ct);
        }

        protected override void Dispose(bool isDisposing)
        {
            if (!_disposed)
            {
                if (isDisposing)
                {
                    if (Client != null)
                        Client.DisposeAsync().AsTask().Wait();
                    if (Sender != null)
                        Sender.DisposeAsync().AsTask().Wait();
                    if (Processor != null)
                        Processor.DisposeAsync().AsTask().Wait();
                }

                _disposed = true;
            }
        }
    }
}
