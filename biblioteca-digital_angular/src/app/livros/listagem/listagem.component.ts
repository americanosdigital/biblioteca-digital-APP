import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { NavbarComponent } from '../../shared/components/navbar/navbar.component';
import { LivroService, Livro } from '../../shared/services/livros.service';

@Component({
  selector: 'app-listagem',
  standalone: true,
  imports: [CommonModule, RouterModule, FormsModule, NavbarComponent ],
  templateUrl: './listagem.component.html',
  styleUrl: './listagem.component.css'
})
export class ListagemComponent implements OnInit {
  livros: Livro[] = [];
  filtro: string = '';
  paginaAtual: number = 0;
  itensPorPagina: number = 5;

  constructor(private livroService: LivroService, private http: HttpClient) {}

  ngOnInit(): void {
   
    this.livroService.listar().subscribe({
    next: (dados) => {
      this.livros = dados;
    },
    error: (err) => {
      console.error('Erro ao carregar livros:', err);
      alert('Erro ao carregar livros. Verifique se a API está rodando.');
    }
  });

  }

  get livrosFiltrados(): Livro[] {
  return this.livros
    .filter(livro => livro.titulo.toLowerCase().includes(this.filtro.toLowerCase()))
    .slice(this.paginaAtual * this.itensPorPagina, (this.paginaAtual + 1) * this.itensPorPagina);
}

excluirLivro(id?: string): void {
  if (!id) return;

  if (confirm('Tem certeza que deseja excluir este livro?')) {
    this.livroService.excluir(id).subscribe(() => {
      this.livros = this.livros.filter(livro => livro.id !== id);

      const maxPaginas = Math.ceil(this.livros.filter(l =>
        l.titulo.toLowerCase().includes(this.filtro.toLowerCase())).length / this.itensPorPagina);

      if (this.paginaAtual >= maxPaginas) {
        this.paginaAtual = Math.max(0, maxPaginas - 1);
      }
    });
  }
}

proximaPagina() {
  if ((this.paginaAtual + 1) * this.itensPorPagina < this.livrosFiltrados.length + this.itensPorPagina) {
    this.paginaAtual++;
  }
}

paginaAnterior() {
  if (this.paginaAtual > 0) {
    this.paginaAtual--;
  }
}

}
