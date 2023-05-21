using System.ComponentModel;

namespace TesteDAlessio.Domain.Entities
{
    public class Contato : EntityBase
    {
        public string? Nome { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }
        [Description("Data de Nascimento")]
        public DateTime DataNascimento { get; set; }
        public int Idade { 
            get
            {

                int anoAtual = 0, anoNascimento = 0, idade = 0;

                if (DataNascimento != null)
                {
                    anoNascimento = DataNascimento.Year;
                    anoAtual = DateTime.Now.Year;

                    idade = anoAtual - anoNascimento;

                    return idade;
                }
                return idade;
            }
        }
        public string? Sexo { get; set; }
        public Cargo? Cargo { get; set; }
    }
}