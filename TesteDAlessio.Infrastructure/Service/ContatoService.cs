using Amazon.SQS.Model;
using Newtonsoft.Json;
using TesteDAlessio.Domain.Entities;
using TesteDAlessio.Domain.Service;
using TesteDAlessio.Infrastructure.Helper;

namespace TesteDAlessio.Infrastructure.Service
{
    public class ContatoMensagemService : IContatoMensagemService
    {
        private readonly ISQSHelper _AWSSQSHelper;
        public ContatoMensagemService(ISQSHelper AWSSQSHelper)
        {
            _AWSSQSHelper = AWSSQSHelper;
        }
        public async Task<bool> PostMensagemAsync(Contato _contato)
        {
            try
            {
                Contato contato = new Contato();
                contato.Id = _contato.Id;
                contato.Nome = _contato.Nome;
                contato.DataNascimento = _contato.DataNascimento;
                contato.Telefone = _contato.Telefone;
                contato.Sexo = _contato.Sexo;
                contato.Ativo = _contato.Ativo;
                contato.DataCriacao = DateTime.UtcNow;
                
                return await _AWSSQSHelper.SendMessageAsync(contato);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<ContatoMensagem>> GetMensagensAsync()
        {
            List<ContatoMensagem>? contatoMensagens = null;
            try
            {
                contatoMensagens = new List<ContatoMensagem>();

                List<Message> messages = await _AWSSQSHelper.ReceiveMessageAsync();
                contatoMensagens = messages.Select(selector: c =>
                {
                    return new ContatoMensagem
                    {
                        MessageId = c.MessageId,
                        ReceiptHandle = c.ReceiptHandle,
                        Contato = JsonConvert.DeserializeObject<Contato>(c.Body)
                    };
                }).ToList();

                return contatoMensagens;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteMensagemAsync(DeleteMensagem deleteMessage)
        {
            try
            {
                return await _AWSSQSHelper.DeleteMessageAsync(deleteMessage.ReceiptHandle);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
