import { Component, OnInit } from '@angular/core';
import { ReservaService } from '../../services/reserva.service';
import { HttpClient } from '@angular/common/http';

@Component({
  standalone :false,
  selector: 'app-historial-reservas',
  templateUrl: './historial-reservas.component.html',
  styleUrls: ['./historial-reservas.component.css']
})
export class HistorialReservasComponent implements OnInit {
  usuarios: any[] = [];
  reservas: any[] = [];
  usuarioSeleccionado: number = 0;

  constructor(private reservaService: ReservaService, private http: HttpClient) {}

  ngOnInit(): void {
    this.http.get<any[]>('http://localhost:5016/api/Usuario').subscribe(data => this.usuarios = data);
  }

  cargarHistorial() {
    if (this.usuarioSeleccionado > 0) {
      this.reservaService.obtenerReservasPorUsuario(this.usuarioSeleccionado).subscribe(data => {
        this.reservas = data;
      });
    }
  }
}
