using TesteDAlessio.Domain.Entities;

namespace TesteDAlessio.Domain.Service
{
    public interface IContatoMensagemService : IServiceBase
    {
        Task<bool> PostMensagemAsync(Contato contato);
        Task<List<ContatoMensagem>> GetMensagensAsync();
        Task<bool> DeleteMensagemAsync(DeleteMensagem deleteMessage);
    }    
}  