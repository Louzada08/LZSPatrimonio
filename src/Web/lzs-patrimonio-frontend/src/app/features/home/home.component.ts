// src/app/features/home/home.component.ts
import { Component, OnInit, signal, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';

// PrimeNG
import { CardModule } from 'primeng/card';
import { ButtonModule } from 'primeng/button';
import { RippleModule } from 'primeng/ripple';

import { UnidadeAdministrativaService } from '../../core/services/unidade-administrativa.service';

interface DashboardCard {
  title: string;
  icon: string;
  color: string;
  count?: number;
  route?: string;
  description: string;
}

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [
    CommonModule,
    CardModule,
    ButtonModule,
    RippleModule
  ],
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  private readonly router = inject(Router);
  private readonly unidadeAdmService = inject(UnidadeAdministrativaService);

  totalUnidadesAdm = signal<number>(0);
  loading = signal<boolean>(false);

  cards: DashboardCard[] = [
    {
      title: 'Unidades Administrativas',
      icon: 'pi pi-building',
      color: '#3B82F6',
      route: '/cadastro/unidade-administrativa',
      description: 'Gerenciar unidades administrativas do sistema'
    },
    {
      title: 'Unidades',
      icon: 'pi pi-sitemap',
      color: '#10B981',
      route: '/cadastro/unidade',
      description: 'Gerenciar unidades organizacionais'
    },
    {
      title: 'Setores',
      icon: 'pi pi-home',
      color: '#F59E0B',
      route: '/cadastro/setor',
      description: 'Gerenciar setores e localizações'
    },
    {
      title: 'Patrimônio',
      icon: 'pi pi-box',
      color: '#8B5CF6',
      route: '/patrimonio',
      description: 'Controle de bens patrimoniais'
    },
    {
      title: 'Movimentações',
      icon: 'pi pi-arrows-h',
      color: '#EC4899',
      route: '/movimentacao',
      description: 'Registrar movimentações de patrimônio'
    },
    {
      title: 'Inventário',
      icon: 'pi pi-list-check',
      color: '#06B6D4',
      route: '/inventario',
      description: 'Realizar inventários patrimoniais'
    },
    {
      title: 'Relatórios',
      icon: 'pi pi-chart-bar',
      color: '#EF4444',
      route: '/relatorios',
      description: 'Visualizar relatórios e estatísticas'
    },
    {
      title: 'Configurações',
      icon: 'pi pi-cog',
      color: '#64748B',
      route: '/configuracoes',
      description: 'Configurações do sistema'
    }
  ];

  ngOnInit(): void {
    this.loadStatistics();
  }

  loadStatistics(): void {
    this.loading.set(true);
    this.unidadeAdmService.getAll().subscribe({
      next: (data) => {
        this.totalUnidadesAdm.set(data.length);
        
        // Atualiza o card de Unidades Administrativas com o total
        const unidadeAdmCard = this.cards.find(c => c.title === 'Unidades Administrativas');
        if (unidadeAdmCard) {
          unidadeAdmCard.count = data.length;
        }
        
        this.loading.set(false);
      },
      error: () => {
        this.loading.set(false);
      }
    });
  }

  navigateTo(route?: string): void {
    if (route) {
      this.router.navigate([route]);
    }
  }
}