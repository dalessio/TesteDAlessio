using Amazon.SQS.Model;
using TesteDAlessio.Domain.Entities;

namespace TesteDAlessio.Infrastructure.Helper
{
    public interface ISQSHelper
    {
        Task<bool> SendMessageAsync(Contato contato);
        Task<List<Message>> ReceiveMessageAsync();
        Task<bool> DeleteMessageAsync(string messageReceiptHandle);
    }
}