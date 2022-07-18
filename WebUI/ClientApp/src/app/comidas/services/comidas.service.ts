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
}