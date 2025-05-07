import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Cancha {
  id: number;
  nombre: string;
  tipo: string;
  ubicacion: string;
}

@Injectable({
  providedIn: 'root'
})
export class CanchaService {
  private apiUrl = 'http://localhost:5016/api/Cancha';

  constructor(private http: HttpClient) {}

  getCanchas(): Observable<Cancha[]> {
    return this.http.get<Cancha[]>(this.apiUrl);
  }

  getCancha(id: number): Observable<Cancha> {
    return this.http.get<Cancha>(`${this.apiUrl}/${id}`);
  }

  createCancha(cancha: Partial<Cancha>): Observable<Cancha> {
    return this.http.post<Cancha>(this.apiUrl, cancha);
  }

  updateCancha(id: number, cancha: Cancha): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}`, cancha);
  }

  deleteCancha(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
