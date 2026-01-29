// src/app/core/services/unidade-administrativa.service.ts
import { Injectable, inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment.development';
import { 
  UnidadeAdministrativaResponse,
  CriarUnidadeAdministrativaRequest
} from '../models/unidade-administrativa.model';
import { 
  PatchOperation 
} from '../models/api-response.model';

@Injectable({
  providedIn: 'root'
})
export class UnidadeAdministrativaService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = `${environment.apiUrl}/UnidadeAdministrativa`;

  getAll(): Observable<UnidadeAdministrativaResponse[]> {
    return this.http.get<UnidadeAdministrativaResponse[]>(`${this.baseUrl}/UnidadeAdmin`);
  }

  getById(id: string): Observable<UnidadeAdministrativaResponse> {
    return this.http.get<UnidadeAdministrativaResponse>(`${this.baseUrl}/${id}`);
  }

  create(request: CriarUnidadeAdministrativaRequest): Observable<UnidadeAdministrativaResponse> {
    return this.http.post<UnidadeAdministrativaResponse>(this.baseUrl, request);
  }

  patch(id: string, operations: PatchOperation[]): Observable<UnidadeAdministrativaResponse> {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json-patch+json'
    });
    
    return this.http.patch<UnidadeAdministrativaResponse>(
      `${this.baseUrl}/${id}`, 
      operations,
      { headers }
    );
  }

  delete(id: string): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }

  createPatchOperation(field: string, value: any): PatchOperation {
    // Capitaliza a primeira letra para corresponder ao C#
    const capitalizedField = field.charAt(0).toUpperCase() + field.slice(1);
    
    return {
      op: 'replace',
      path: `/${capitalizedField}`,
      value: value
    };
  }
}