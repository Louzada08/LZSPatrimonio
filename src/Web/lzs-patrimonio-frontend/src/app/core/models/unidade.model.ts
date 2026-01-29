// src/app/core/models/unidade.model.ts
import { UnidadeAdministrativa } from './unidade-administrativa.model';
import { Setor } from './setor.model';

export interface Unidade {
  id: string;
  unidadeAdministrativaId: string;
  unidadeAdministrativa?: UnidadeAdministrativa;
  codigoInterno: number;
  nome: string;
  sigla: string;
  tipoFundo: FundoEnum;
  setores?: Setor[];
  criadoEmUtc: Date;
  atualizadoEmUtc: Date;
  deletadoEmUtc?: Date;
}

export enum FundoEnum {
  Municipal = 0,
  Estadual = 1,
  Federal = 2
}

export interface CriarUnidadeRequest {
  unidadeAdministrativaId: string;
  codigoInterno: number;
  nome: string;
  sigla: string;
  tipoFundo: FundoEnum;
}