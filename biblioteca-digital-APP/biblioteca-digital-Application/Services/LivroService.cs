
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using biblioteca_digital_Application.Interfaces;
using biblioteca_digital_DOMAIN.Entities;
using biblioteca_digital_DOMAIN.Interfaces;

namespace biblioteca_digital_Application.Services
{
    public class LivroService : ILivroService
    {
        private readonly ILivroRepository _livroRepository;

        public LivroService(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        public async Task<IEnumerable<Livro>> ObterTodosAsync()
        {
            return await _livroRepository.ObterTodosAsync();
        }

        public async Task<Livro?> ObterPorIdAsync(Guid id)
        {
            return await _livroRepository.ObterPorIdAsync(id);
        }

        public async Task<Livro> CriarAsync(Livro livro)
        {
            livro.Id = Guid.NewGuid();
            await _livroRepository.AdicionarAsync(livro);
            return livro;
        }

        public async Task AtualizarAsync(Livro livro)
        {
            await _livroRepository.AtualizarAsync(livro);
        }

        public async Task RemoverAsync(Guid id)
        {
            await _livroRepository.RemoverAsync(id);
        }
    }

}
