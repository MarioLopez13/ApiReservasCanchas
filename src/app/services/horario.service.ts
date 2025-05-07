import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HorarioService {
  private apiUrl = 'https://apireservascanchas.onrender.com/api/Horario';

  constructor(private http: HttpClient) {}

  getHorariosPorCancha(canchaId: number): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/porCancha/${canchaId}`);
  }

  agregarHorario(horario: any): Observable<any> {
    return this.http.post<any>(this.apiUrl, horario);
  }

  eliminarHorario(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
