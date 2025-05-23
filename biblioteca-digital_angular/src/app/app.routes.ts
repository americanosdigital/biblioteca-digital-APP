import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ListagemComponent } from './livros/listagem/listagem.component';
import { FormularioComponent } from './livros/formulario/formulario.component';
import { DetalhesComponent } from './livros/detalhes/detalhes.component';

export const routes: Routes = [
  {
    path: '',
    loadComponent: () => import('./home/home.component').then(m => m.HomeComponent)
  },
  {
    path: 'listagem',
    loadComponent: () => import('./livros/listagem/listagem.component').then(m => m.ListagemComponent)
  },
  {
    path: 'formulario',
    loadComponent: () => import('./livros/formulario/formulario.component').then(m => m.FormularioComponent)
  },
  {
    path: 'formulario/:id',
    loadComponent: () => import('./livros/formulario/formulario.component').then(m => m.FormularioComponent)
  },
  {
    path: 'detalhes/:id',
    loadComponent: () => import('./livros/detalhes/detalhes.component').then(m => m.DetalhesComponent)
  },
  { path: '**', redirectTo: '' } // fallback
];

