using System;
using System.Windows.Forms;
using Confluent.Kafka;
using System.Threading;
using System.Threading.Tasks;

namespace KafkaChatApp
{
    public partial class Form1 : Form
    {
        private const string bootstrapServers = "localhost:9092";
        private const string topicName = "chat-topic";
        private IProducer<Null, string> producer;
        private CancellationTokenSource cts;

        public Form1()
        {
            InitializeComponent();
            InitializeKafkaProducer();
            StartKafkaConsumer();
        }

        private void InitializeKafkaProducer()
        {
            var config = new ProducerConfig
            {
                BootstrapServers = bootstrapServers
            };

            producer = new ProducerBuilder<Null, string>(config).Build();
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            string message = txtMessage.Text.Trim();

            if (!string.IsNullOrEmpty(message))
            {
                try
                {
                    await producer.ProduceAsync(topicName, new Message<Null, string> { Value = message });
                    txtMessage.Clear();
                }
                catch (ProduceException<Null, string> ex)
                {
                    MessageBox.Show($"Error sending message: {ex.Error.Reason}", "Producer Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void StartKafkaConsumer()
        {
            cts = new CancellationTokenSource();

            Task.Run(() =>
            {
                var config = new ConsumerConfig
                {
                    BootstrapServers = bootstrapServers,
                    GroupId = Guid.NewGuid().ToString(),
                    AutoOffsetReset = AutoOffsetReset.Earliest
                };

                using (var consumer = new ConsumerBuilder<Ignore, string>(config).Build())
                {
                    consumer.Subscribe(topicName);

                    try
                    {
                        while (!cts.Token.IsCancellationRequested)
                        {
                            var result = consumer.Consume(cts.Token);
                            if (result != null)
                            {
                                Invoke(new Action(() =>
                                {
                                    txtChat.AppendText($"[{DateTime.Now:HH:mm:ss}] {result.Message.Value}{Environment.NewLine}");
                                }));
                            }
                        }
                    }
                    catch (OperationCanceledException) { }
                    finally
                    {
                        consumer.Close();
                    }
                }
            }, cts.Token);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            cts?.Cancel();
            producer?.Dispose();
            base.OnFormClosing(e);
        }
    }
}
