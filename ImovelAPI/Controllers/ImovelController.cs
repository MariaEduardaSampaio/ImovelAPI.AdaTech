using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace ImovelAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImovelController : ControllerBase
    {
        public List<ImovelApi> _imoveis { get; set; }
        private static int contadorId = 3;

        public ImovelController()
        {
            _imoveis = new List<ImovelApi>
            {
                new ImovelApi(1, "Jo�o Silva", "Rua das Flores, 123"),
                new ImovelApi(2, "Maria Souza", "Avenida Principal, 456"),
                new ImovelApi(3, "Jos� Santos", "Pra�a da Paz, 789"),
            };
        }

        [HttpGet("/imoveis", Name = "Pegar todos os im�veis")]
        public IActionResult PegarTodosOsImoveis()
        {
            return Ok(_imoveis);
        }

        [HttpGet("/imovel/{id}", Name = "Pegar o im�vel com este ID")]
        public IActionResult PegarImovelPorID(int id)
        {
            var findImovel = _imoveis.FirstOrDefault(i => i.Id == id);
            return Ok(findImovel);
        }

        [HttpPost("/adicionarImovel", Name = "Adicionar im�vel")]
        public IActionResult AdicionarImovel(string proprietario, string endereco)
        {
            var imovelNovo = new ImovelApi(++contadorId, proprietario, endereco);
            _imoveis.Add(imovelNovo);
            return Ok(imovelNovo.Id);
        }
    }
}
