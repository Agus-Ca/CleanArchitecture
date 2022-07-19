import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Observable } from 'rxjs';

import { environment } from 'src/environments/environment';
import { Comida } from '../interfaces/comida.interface';

@Injectable({
  providedIn: 'root'
})
export class ComidasService {

  constructor( private http: HttpClient ) { }

  baseUrl: string = environment.baseUrl;

  getComidas():Observable<Comida[]> {
    return this.http.get<Comida[]>(`${ this.baseUrl }/comida`);
  }

  getComidaById( ComidaId: number ): Observable<Comida> {
    return this.http.get<Comida>(`${ this.baseUrl }/comida/GetById?ComidaId=${ComidaId}`);
  }

  addComida( comida: Comida): Observable<Comida> {
    return this.http.post<Comida>(`${ this.baseUrl }/comida`, comida)
  }

  updateComida( comida: Comida ): Observable<any> {
    return this.http.put(`${ this.baseUrl }/comida`, comida);
  }

  deleteComida( idComida: number ): Observable<any> {
    return this.http.delete(`${ this.baseUrl }/comida?IdComida=${idComida}`);
  }
}