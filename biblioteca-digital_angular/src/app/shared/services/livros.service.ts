import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

export interface Livro {
  id: string;           
  titulo: string;
  autor: string;
  ano: number;
  genero: string;
}

@Injectable({
  providedIn: 'root'
})
export class LivroService {
  // Corrigido: Incluído '/api' na URL base
  private apiUrl = `${environment.apiUrl}/api/Livros`;

  constructor(private http: HttpClient) {}

  listar(): Observable<Livro[]> {
    return this.http.get<Livro[]>(this.apiUrl);
  }

  buscarPorId(id: string): Observable<Livro> {  
    return this.http.get<Livro>(`${this.apiUrl}/${id}`);
  }

  criar(livro: Livro): Observable<Livro> {
    return this.http.post<Livro>(this.apiUrl, livro);
  }

  atualizar(id: string, livro: Livro): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}`, livro);
  }

  excluir(id: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
