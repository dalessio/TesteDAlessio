namespace TesteDAlessio.UI.WebApp.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public bool Ativo { get; set; }
        public required string Login { get; set; }
        public required string Senha { get; set; }
    }
}