using Questao5.Domain.Entities;

namespace Questao5.Application.Handlers
{
    public interface ICreateMovimentoResponse
    {
        Task<IEnumerable<Movimento>> Get(string idcontacorrente);
    }
}
