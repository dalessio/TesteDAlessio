namespace TesteDAlessio.UI.WebApp.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public DateTime? DataCriacao { get; set; }
        public bool Ativo { get; set; }
        public string? Login { get; set; }
        public string? Senha { get; set; }

        public string? Mensagem { get; set; }
    }
}