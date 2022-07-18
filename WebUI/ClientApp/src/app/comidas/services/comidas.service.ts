import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Comida } from '../interfaces/comida.interface';

@Injectable({
  providedIn: 'root'
})
export class ComidasService {

  constructor( private http: HttpClient ) { }

  getComidas():Observable<Comida[]> {
    return this.http.get<Comida[]>('https://localhost:7203/api/Comida');
  }

  getComidaById( ComidaId: number ): Observable<Comida> {
    return this.http.get<Comida>(`https://localhost:7203/api/Comida/GetById?ComidaId=${ComidaId}`);
  }

  addComida( comida: Comida): Observable<Comida> {
    return this.http.post<Comida>(`https://localhost:7203/api/Comida`, comida)
  }

  updateComida( comida: Comida ): Observable<any> {
    return this.http.put(`https://localhost:7203/api/Comida`, comida);
  }

  deleteComida( idComida: number ): Observable<any> {
    return this.http.delete(`https://localhost:7203/api/Comida?IdComida=${idComida}`);
  }
}