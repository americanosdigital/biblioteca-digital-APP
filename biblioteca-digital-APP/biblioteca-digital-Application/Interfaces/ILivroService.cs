using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using biblioteca_digital_DOMAIN.Entities;

namespace biblioteca_digital_Application.Interfaces
{
    public interface ILivroService
    {
        Task<IEnumerable<Livro>> ObterTodosAsync();
        Task<Livro?> ObterPorIdAsync(Guid id);
        Task<Livro> CriarAsync(Livro livro);
        Task AtualizarAsync(Livro livro);
        Task RemoverAsync(Guid id);
    }

}
