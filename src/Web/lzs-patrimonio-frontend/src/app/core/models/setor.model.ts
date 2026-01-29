export class Unidade {}
// src/app/core/models/setor.model.ts
export interface Setor {
  id: string;
  unidadeId: string;
  unidade?: Unidade;
  codigoInterno: number;
  nome: string;
  localFisico: string;
  criadoEmUtc: Date;
  atualizadoEmUtc: Date;
  deletadoEmUtc?: Date;
}

export interface CriarSetorRequest {
  unidadeId: string;
  codigoInterno: number;
  nome: string;
  localFisico: string;
}

