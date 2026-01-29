// src/app/features/cadastro/unidade-administrativa/unidade-administrativa-list.component.ts
import { Component, OnInit, signal, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { ConfirmationService, MessageService } from 'primeng/api';

// PrimeNG
import { TableModule } from 'primeng/table';
import { ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';
import { ToolbarModule } from 'primeng/toolbar';
import { TooltipModule } from 'primeng/tooltip';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { RippleModule } from 'primeng/ripple';

import { UnidadeAdministrativaService } from '../../../core/services/unidade-administrativa.service';
import { UnidadeAdministrativaResponse } from '../../../core/models/unidade-administrativa.model';

@Component({
  selector: 'app-unidade-administrativa-list',
  standalone: true,
  imports: [
    CommonModule,
    TableModule,
    ButtonModule,
    InputTextModule,
    ToolbarModule,
    TooltipModule,
    ConfirmDialogModule,
    RippleModule
  ],
  templateUrl: './unidade-administrativa-list.component.html',
  styleUrls: ['./unidade-administrativa-list.component.scss']
})
export class UnidadeAdministrativaListComponent implements OnInit {
  private readonly service = inject(UnidadeAdministrativaService);
  private readonly router = inject(Router);
  private readonly messageService = inject(MessageService);
  private readonly confirmationService = inject(ConfirmationService);

  unidadesAdministrativas = signal<UnidadeAdministrativaResponse[]>([]);
  loading = signal<boolean>(false);

  ngOnInit(): void {
    this.loadData();
  }

  loadData(): void {
    this.loading.set(true);
    this.service.getAll().subscribe({
      next: (data) => {
        this.unidadesAdministrativas.set(data);
        this.loading.set(false);
      },
      error: () => {
        this.loading.set(false);
      }
    });
  }

  create(): void {
    this.router.navigate(['/cadastro/unidade-administrativa/novo']);
  }

  edit(id: string): void {
    this.router.navigate(['/cadastro/unidade-administrativa/editar', id]);
  }

  view(id: string): void {
    this.router.navigate(['/cadastro/unidade-administrativa/visualizar', id]);
  }

  delete(id: string, nome: string): void {
    this.confirmationService.confirm({
      message: `Deseja realmente excluir a Unidade Administrativa "${nome}"?`,
      header: 'Confirmação de Exclusão',
      icon: 'pi pi-exclamation-triangle',
      acceptLabel: 'Sim',
      rejectLabel: 'Não',
      accept: () => {
        this.service.delete(id).subscribe({
          next: () => {
            this.messageService.add({
              severity: 'success',
              summary: 'Sucesso',
              detail: 'Unidade Administrativa excluída com sucesso'
            });
            this.loadData();
          }
        });
      }
    });
  }
}