using Questao5.Domain.Entities;

namespace Questao5.Application.Handlers
{
    public interface ICreateMovimentoRequest
    {
        Task Create(Movimento movimento);
    }
}
