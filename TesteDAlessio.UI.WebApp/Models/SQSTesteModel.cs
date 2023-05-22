using Amazon.SQS.Model;

namespace TesteDAlessio.UI.WebApp.Models
{
    public class SQSTesteModel
    {
        public Message? Message { get; set; }
        public string? MessageBody { get; set; }
        public IList<Message>? Messages { get; set; }
        
        public SQSTesteModel()
        {
            Messages = new List<Message>();
            Message = new Message();
        }
    }
}
