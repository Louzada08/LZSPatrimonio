// src/app/features/cadastro/unidade-administrativa/unidade-administrativa-form.component.ts
import { Component, OnInit, signal, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { MessageService } from 'primeng/api';

// PrimeNG
import { ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';
import { InputNumberModule } from 'primeng/inputnumber';
import { ToolbarModule } from 'primeng/toolbar';
import { RippleModule } from 'primeng/ripple';

import { UnidadeAdministrativaService } from '../../../core/services/unidade-administrativa.service';
import { CriarUnidadeAdministrativaRequest } from '../../../core/models/unidade-administrativa.model';

@Component({
  selector: 'app-unidade-administrativa-form',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    ButtonModule,
    InputTextModule,
    InputNumberModule,
    ToolbarModule,
    RippleModule
  ],
  templateUrl: './unidade-administrativa-form.component.html',
  styleUrls: ['./unidade-administrativa-form.component.scss']
})
export class UnidadeAdministrativaFormComponent implements OnInit {
  private readonly fb = inject(FormBuilder);
  private readonly service = inject(UnidadeAdministrativaService);
  private readonly router = inject(Router);
  private readonly route = inject(ActivatedRoute);
  private readonly messageService = inject(MessageService);

  form!: FormGroup;
  isEditMode = signal<boolean>(false);
  isViewMode = signal<boolean>(false);
  loading = signal<boolean>(false);
  unidadeAdmId = signal<string | null>(null);

  ngOnInit(): void {
    this.initializeForm();
    this.checkMode();
  }

  initializeForm(): void {
    this.form = this.fb.group({
      codigoInterno: [null, [Validators.required, Validators.min(1)]],
      nome: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(200)]]
    });
  }

  checkMode(): void {
    const id = this.route.snapshot.paramMap.get('id');
    const urlSegments = this.route.snapshot.url;
    
    // Pega o segmento antes do ID (editar ou visualizar)
    const path = urlSegments.length >= 2 ? urlSegments[1]?.path : null;

    console.log('=== DEBUG CHECK MODE ===');
    console.log('ID:', id);
    console.log('URL Segments:', urlSegments);
    console.log('Path detectado:', path);

    if (id) {
      this.unidadeAdmId.set(id);
      this.isEditMode.set(path === 'editar');
      this.isViewMode.set(path === 'visualizar');
      
      console.log('isEditMode será:', path === 'editar');
      console.log('isViewMode será:', path === 'visualizar');
      
      this.loadData(id);
    }

    if (this.isViewMode()) {
      this.form.disable();
    }
  }

  loadData(id: string): void {
    this.loading.set(true);
    this.service.getById(id).subscribe({
      next: (data) => {
        this.form.patchValue({
          codigoInterno: data.codigoInterno,
          nome: data.nome
        });
        this.loading.set(false);
      },
      error: () => {
        this.loading.set(false);
        this.router.navigate(['/cadastro/unidade-administrativa']);
      }
    });
  }

  save(): void {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      this.messageService.add({
        severity: 'warn',
        summary: 'Atenção',
        detail: 'Preencha todos os campos obrigatórios corretamente'
      });
      return;
    }

    console.log('=== DEBUG SAVE ===');
    console.log('isEditMode:', this.isEditMode());
    console.log('isViewMode:', this.isViewMode());
    console.log('unidadeAdmId:', this.unidadeAdmId());
    console.log('URL atual:', this.route.snapshot.url);
    console.log('Path:', this.route.snapshot.url[0]?.path);

    this.loading.set(true);
    const formValue = this.form.value;

    if (this.isEditMode() && this.unidadeAdmId()) {
      console.log('Chamando UPDATE');
      this.update(formValue);
    } else {
      console.log('Chamando CREATE');
      this.create(formValue);
    }
  }

  create(formValue: any): void {
    const request: CriarUnidadeAdministrativaRequest = {
      codigoInterno: formValue.codigoInterno,
      nome: formValue.nome
    };

    this.service.create(request).subscribe({
      next: () => {
        this.messageService.add({
          severity: 'success',
          summary: 'Sucesso',
          detail: 'Unidade Administrativa criada com sucesso'
        });
        this.router.navigate(['/cadastro/unidade-administrativa']);
      },
      error: () => {
        this.loading.set(false);
      }
    });
  }

  update(formValue: any): void {
    const operations = [];

    if (this.form.get('codigoInterno')?.dirty) {
      operations.push(this.service.createPatchOperation('codigoInterno', formValue.codigoInterno));
    }

    if (this.form.get('nome')?.dirty) {
      operations.push(this.service.createPatchOperation('nome', formValue.nome));
    }

    if (operations.length === 0) {
      this.messageService.add({
        severity: 'info',
        summary: 'Informação',
        detail: 'Nenhuma alteração detectada'
      });
      this.loading.set(false);
      return;
    }

    this.service.patch(this.unidadeAdmId()!, operations).subscribe({
      next: () => {
        this.messageService.add({
          severity: 'success',
          summary: 'Sucesso',
          detail: 'Unidade Administrativa atualizada com sucesso'
        });
        this.router.navigate(['/cadastro/unidade-administrativa']);
      },
      error: () => {
        this.loading.set(false);
      }
    });
  }

  cancel(): void {
    this.router.navigate(['/cadastro/unidade-administrativa']);
  }

  isFieldInvalid(fieldName: string): boolean {
    const field = this.form.get(fieldName);
    return !!(field && field.invalid && (field.dirty || field.touched));
  }

  getFieldError(fieldName: string): string {
    const field = this.form.get(fieldName);
    
    if (field?.hasError('required')) {
      return 'Campo obrigatório';
    }
    if (field?.hasError('minlength')) {
      return `Mínimo de ${field.errors?.['minlength'].requiredLength} caracteres`;
    }
    if (field?.hasError('maxlength')) {
      return `Máximo de ${field.errors?.['maxlength'].requiredLength} caracteres`;
    }
    if (field?.hasError('min')) {
      return `Valor mínimo: ${field.errors?.['min'].min}`;
    }
    
    return '';
  }
}