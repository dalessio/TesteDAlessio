using Amazon.SQS.Model;
using Newtonsoft.Json;

namespace TesteDAlessio.UI.WebApp.Helpers
{
    public interface IAWSSQSService
    {
        Task<bool> PostMessageAsync(String message);
        Task<List<Message>> GetAllMessagesAsync();
        //Task<bool> DeleteMessageAsync(DeleteMessage deleteMessage);
    }
    public class AWSSQSService : IAWSSQSService
    {
        private readonly IAWSSQSHelper _AWSSQSHelper;
        public AWSSQSService(IAWSSQSHelper AWSSQSHelper)
        {
            this._AWSSQSHelper = AWSSQSHelper;
        }
        public async Task<bool> PostMessageAsync(String message)
        {
            try
            {
                return await _AWSSQSHelper.SendMessageAsync(message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<Message>> GetAllMessagesAsync()
        {
            List<Message> allMessages = new List<Message>();
            try
            {
                List<Message> messages = await _AWSSQSHelper.ReceiveMessageAsync();
                allMessages = messages.ToList();

                return allMessages;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public async Task<bool> DeleteMessageAsync(DeleteMessage deleteMessage)
        //{
        //    try
        //    {
        //        return await _AWSSQSHelper.DeleteMessageAsync(deleteMessage.ReceiptHandle);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}