using Microsoft.AspNetCore.Mvc;
using TesteDAlessio.Domain.Entities;

namespace TesteDAlessio.UI.WebAi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MockContatoController : ControllerBase
    {
        private static readonly string[] Nomes = new[]
        {
        "Jessica", "Lorena", "Carla", "Maria", "Natalia", "Biaca", "Amanda", "Cristiane", "Márcia", "Ana Paula"
    };

        private readonly ILogger<MockContatoController> _logger;

        public MockContatoController(ILogger<MockContatoController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetContatosMock")]
        public IEnumerable<Contato> GetContatosMock()
        {
            return Enumerable.Range(1, Nomes.Length).Select(index => new Contato
            {
                Id = Random.Shared.Next(0, 100),
                DataCriacao = DateTime.Now,
                Ativo = true,
                Nome = Nomes[Random.Shared.Next(Nomes.Length)],
                Email = string.Format("emailcontato{0}@email.com", Random.Shared.Next(0, 100)),
                Telefone = Random.Shared.Next(900000000, 999999999).ToString(),
                DataNascimento = DateTime.Now.AddYears(Random.Shared.Next(-60, -20)),
                Sexo = "F"
            })
            .ToArray();
        }
    }
}