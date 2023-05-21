namespace TesteDAlessio.Domain.Entities
{
    public class ContatoMensagem : Mensagem<Contato>
    {
        public Contato? Contato { get; set; }

        public ContatoMensagem()
        {
            Contato = new Contato();
        }
    }
}
