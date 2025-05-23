using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace biblioteca_digital_DOMAIN.Entities
{
    public class Livro
    {
        public Guid Id { get; set; } 
        public string Titulo { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;
        public int Ano { get; set; }
        public string Genero { get; set; } = string.Empty;

        public Livro() { }

        public Livro(string titulo, string autor, int ano, string genero)
        {
            Id = Guid.NewGuid(); 
            Titulo = titulo;
            Autor = autor;
            Ano = ano;
            Genero = genero;
        }

        public static Livro Criar(string Titulo, string Autor, int Ano, string Genero)
        {
            return new Livro(Titulo, Autor, Ano, Genero);
        }

        public void Atualizar(string titulo, string autor, int ano, string genero)
        {
            Titulo = titulo;
            Autor = autor;
            Ano = ano;
            Genero = genero;
        }

        public void Remover()
        {
            // Lógica para remover o livro, se necessário
        }   
    }

}
