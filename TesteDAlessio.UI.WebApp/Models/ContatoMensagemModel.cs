namespace TesteDAlessio.UI.WebApp.Models
{
    public class ContatoMensagemModel
    {
        public int Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public bool Ativo { get; set; }
        public ContatoModel? Contato { get; set; }
        public ContatoMensagemModel()
        {
            Contato = new ContatoModel();
        }
    }
}
