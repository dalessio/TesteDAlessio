using Amazon.SQS;
using Amazon.SQS.Model;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using TesteDAlessio.Domain.Entities;

namespace TesteDAlessio.Infrastructure.Helper
{
    public class SQSHelper : ISQSHelper
    {
        private readonly IAmazonSQS _sqs;
        private readonly SQSServiceConfiguration _settings;
        public SQSHelper(
           IAmazonSQS sqs,
           IOptions<SQSServiceConfiguration> settings)
        {
            _sqs = sqs;
            _settings = settings.Value;
        }
        public async Task<bool> SendMessageAsync(Contato contato)
        {
            try
            {
                string message = JsonConvert.SerializeObject(contato);
                var sendRequest = new SendMessageRequest(_settings.AWSSQS.QueueUrl, message);
                // Post message or payload to queue  
                var sendResult = await _sqs.SendMessageAsync(sendRequest);

                return sendResult.HttpStatusCode == System.Net.HttpStatusCode.OK;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<Message>> ReceiveMessageAsync()
        {
            try
            {
                //Create New instance  
                var request = new ReceiveMessageRequest
                {
                    QueueUrl = _settings.AWSSQS.QueueUrl,
                    MaxNumberOfMessages = 10,
                    WaitTimeSeconds = 5
                };
                //CheckIs there any new message available to process  
                var result = await _sqs.ReceiveMessageAsync(request);

                return result.Messages.Any() ? result.Messages : new List<Message>();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<bool> DeleteMessageAsync(string messageReceiptHandle)
        {
            try
            {
                //Deletes the specified message from the specified queue  
                var deleteResult = await _sqs.DeleteMessageAsync(
                    queueUrl: _settings.AWSSQS.QueueUrl,
                    messageReceiptHandle);
                return deleteResult.HttpStatusCode == System.Net.HttpStatusCode.OK;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}