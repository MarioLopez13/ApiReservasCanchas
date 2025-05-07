import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ReservaService {
  private apiUrl = 'http://localhost:5016/api/Reserva';

  constructor(private http: HttpClient) {}

  crearReserva(reserva: any): Observable<any> {
    return this.http.post(this.apiUrl, reserva);
  }

  obtenerReservasPorUsuario(usuarioId: number): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/porUsuario/${usuarioId}`);
  }

  eliminarReserva(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
