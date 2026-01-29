// src/app/app.routes.ts
import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    redirectTo: '/home',
    pathMatch: 'full'
  },
  {
    path: 'home',
    loadComponent: () => 
      import('./features/home/home.component')
        .then(m => m.HomeComponent)
  },
  {
    path: 'cadastro',
    children: [
      {
        path: 'unidade-administrativa',
        loadComponent: () => 
          import('./features/cadastro/unidade-administrativa/unidade-administrativa-list.component')
            .then(m => m.UnidadeAdministrativaListComponent)
      },
      {
        path: 'unidade-administrativa/novo',
        loadComponent: () => 
          import('./features/cadastro/unidade-administrativa/unidade-administrativa-form.component')
            .then(m => m.UnidadeAdministrativaFormComponent)
      },
      {
        path: 'unidade-administrativa/editar/:id',
        loadComponent: () => 
          import('./features/cadastro/unidade-administrativa/unidade-administrativa-form.component')
            .then(m => m.UnidadeAdministrativaFormComponent)
      },
      {
        path: 'unidade-administrativa/visualizar/:id',
        loadComponent: () => 
          import('./features/cadastro/unidade-administrativa/unidade-administrativa-form.component')
            .then(m => m.UnidadeAdministrativaFormComponent)
      }
    ]
  },
  {
    path: '**',
    redirectTo: '/home'
  }
];