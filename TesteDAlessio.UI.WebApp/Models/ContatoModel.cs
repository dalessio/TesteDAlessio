namespace TesteDAlessio.UI.WebApp.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }
        public DateTime? DataCriacao { get; set; }
        public bool Ativo { get; set; }
        public string? Nome { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string MaxDataNascimento { get {
                string maxDate = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day;
                return maxDate;

            }  }
        public int Idade
        {
            get
            {
                if (DataNascimento.HasValue)
                {
                    int anoAtual = 0, anoNascimento = 0, idade = 0;

                    anoNascimento = DataNascimento.Value.Year;
                    anoAtual = DateTime.Now.Year;

                    idade = anoAtual - anoNascimento;

                    return idade;
                }
                return 0;
            }
        }
        public string? Sexo { get; set; }
        public int CargoId { get; set; }
        public IList<CargoModel>? Cargos { get; set; }
    }
}