namespace TesteDAlessio.Infrastructure.Helper
{
    public class SQSServiceConfiguration
    {
        public required AWSSQS AWSSQS { get; set; }
    }
    public class AWSSQS
    {
        public required string QueueUrl { get; set; }
    }
}
