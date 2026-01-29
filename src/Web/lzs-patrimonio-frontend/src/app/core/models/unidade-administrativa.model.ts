// src/app/core/models/unidade-administrativa.model.ts
import { Unidade } from './unidade.model';

export interface UnidadeAdministrativa {
  id: string;
  codigoInterno: number;
  nome: string;
  unidades?: Unidade[];
  criadoEmUtc: Date;
  atualizadoEmUtc: Date;
  deletadoEmUtc?: Date;
}

export interface CriarUnidadeAdministrativaRequest {
  codigoInterno: number;
  nome: string;
}

export interface PatchUnidadeAdministrativaRequisicao {
  codigoInterno: number;
  nome: string;
}

export interface UnidadeAdministrativaResponse {
  id: string;
  codigoInterno: number;
  nome: string;
  criadoEmUtc: Date;
  atualizadoEmUtc: Date;
}
