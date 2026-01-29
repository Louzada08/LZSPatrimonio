// src/app/app.component.ts
import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { ToastModule } from 'primeng/toast';
import { ProgressSpinnerModule } from 'primeng/progressspinner';
import { LoadingService } from './core/services/loading.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    CommonModule,
    RouterOutlet,
    ToastModule,
    ProgressSpinnerModule
  ],
  template: `
    <div class="layout-wrapper">
      <div class="layout-main">
        <div class="layout-content">
          <router-outlet />
        </div>
      </div>
    </div>

    <p-toast position="top-right" />

    @if (loadingService.loading()) {
      <div class="loading-overlay">
        <p-progressSpinner 
          [style]="{width: '50px', height: '50px'}"
          strokeWidth="4"
          animationDuration="1s" />
      </div>
    }
  `,
  styles: [`
    .layout-wrapper {
      min-height: 100vh;
      background-color: #f8f9fa;
    }

    .layout-main {
      padding: 2rem;
    }

    .loading-overlay {
      position: fixed;
      top: 0;
      left: 0;
      width: 100%;
      height: 100%;
      background-color: rgba(0, 0, 0, 0.5);
      display: flex;
      align-items: center;
      justify-content: center;
      z-index: 9999;
    }
  `]
})
export class AppComponent {
  readonly loadingService = inject(LoadingService);
}