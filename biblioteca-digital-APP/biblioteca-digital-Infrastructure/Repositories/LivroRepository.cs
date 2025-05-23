using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using biblioteca_digital_DOMAIN.Entities;
using biblioteca_digital_DOMAIN.Interfaces;
using biblioteca_digital_Infrastructure.Context;

namespace biblioteca_digital_Infrastructure.Repositories
{
    public class LivroRepository : ILivroRepository
    {
        private readonly AppDbContext _context;

        public LivroRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Livro>> ObterTodosAsync() =>
            await _context.Livros.ToListAsync();

        public async Task<Livro?> ObterPorIdAsync(Guid id) =>
            await _context.Livros.FindAsync(id);

        public async Task AdicionarAsync(Livro livro)
        {
            await _context.Livros.AddAsync(livro);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Livro livro)
        {
            _context.Livros.Update(livro);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(Guid id)
        {
            var livro = await _context.Livros.FindAsync(id);
            if (livro is not null)
            {
                _context.Livros.Remove(livro);
                await _context.SaveChangesAsync();
            }
        }
    }

}
