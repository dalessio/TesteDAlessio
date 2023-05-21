namespace TesteDAlessio.Domain.Entities
{
    public abstract class Mensagem<T> : EntityBase where T : EntityBase
    {
        public required string MessageId { get; set; }
        public required string ReceiptHandle { get; set; }        
    }
    public class DeleteMensagem
    {
        public required string ReceiptHandle { get; set; }
    }
}