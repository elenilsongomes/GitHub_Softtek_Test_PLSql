using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Questao5.Application.Handlers;
using Questao5.Domain.Entities;

namespace Questao5.Infrastructure.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountBalancesController : ControllerBase
    {

        private readonly ICreateMovimentoResponse createMovimentoResponse;

        public AccountBalancesController(ICreateMovimentoResponse createMovimentoResponse)
        {
            this.createMovimentoResponse = createMovimentoResponse;
        }

        [HttpGet(Name = "GetAccountBalances")]
        public async Task<IEnumerable<Movimento>> Get(string idcontacorrente)
        {
            return await createMovimentoResponse.Get(idcontacorrente);
        }
    }
}
