import { Component, OnInit } from '@angular/core';
import { ReservaService } from '../../services/reserva.service';
import { CanchaService } from '../../services/cancha.service';
import { HttpClient } from '@angular/common/http';

@Component({
  standalone: false,
  selector: 'app-reservas',
  templateUrl: './reservas.component.html',
  styleUrls: ['./reservas.component.css']
})
export class ReservasComponent implements OnInit {
  canchas: any[] = [];
  usuarios: any[] = [];
  mensaje: string = '';
  nuevaReserva = {
    usuarioId: 0,
    canchaId: 0,
    fecha: '',
    horaInicio: '',
    horaFin: '',
    estado: 'Activa',
    precioFinal: 10.00
  };

  constructor(
    private reservaService: ReservaService,
    private canchaService: CanchaService,
    private http: HttpClient
  ) {}

  ngOnInit(): void {
    this.cargarCanchas();
    this.cargarUsuarios();
  }

  cargarCanchas() {
    this.canchaService.getCanchas().subscribe(data => this.canchas = data);
  }

  cargarUsuarios() {
    this.http.get<any[]>('http://localhost:5016/api/Usuario').subscribe(data => this.usuarios = data);
  }

  crearReserva() {
    this.reservaService.crearReserva(this.nuevaReserva).subscribe({
      next: () => {
        this.mensaje = 'Reserva creada exitosamente.';
        this.nuevaReserva.horaInicio = '';
        this.nuevaReserva.horaFin = '';
      },
      error: (err) => {
        this.mensaje = err.error; // muestra mensaje del backend
      }
    });
  }
}
