namespace TesteDAlessio.Domain.Entities
{
    public class Usuario : EntityBase
    {
        public required string Login { get; set; }
        public required string Senha { get; set; }
    }
}