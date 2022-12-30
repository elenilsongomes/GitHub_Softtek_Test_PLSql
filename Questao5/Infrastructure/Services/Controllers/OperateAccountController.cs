using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Questao5.Application.Handlers;
using Questao5.Domain.Entities;
using Questao5.Infrastructure.Sqlite;

namespace Questao5.Infrastructure.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperateAccountController : ControllerBase
    {
        private readonly ICreateMovimentoRequest createMovimentoRequest;

        public OperateAccountController(ICreateMovimentoRequest createMovimentoRequest)
        {
            this.createMovimentoRequest = createMovimentoRequest;
        }

        [HttpPost]
        public async Task Post([FromBody] Movimento movimento)
        {
            await createMovimentoRequest.Create(movimento);
        }
    }
}
