// src/app/core/models/api-response.model.ts
export interface ApiResponse<T> {
  data?: T;
  errors?: ValidationError[];
  success: boolean;
}

export interface ValidationError {
  propertyName: string;
  errorMessage: string;
  errorCode?: number;
}

export interface PatchOperation {
  op: string;
  path: string;
  value: any;
}