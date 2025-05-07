// src/app/pages/horarios/horarios.component.ts
import { Component, OnInit } from '@angular/core';
import { HorarioService } from '../../services/horario.service';

@Component({
  standalone :false,
  selector: 'app-horarios',
  templateUrl: './horarios.component.html',
  styleUrls: ['./horarios.component.css']
})
export class HorariosComponent implements OnInit {
  horarios: any[] = [];
  canchaId = 1; // cambiar dinámicamente si hace falta
  nuevoHorario = {
    canchaId: 1,
    horaInicio: '',
    horaFin: '',
    disponible: true
  };

  constructor(private horarioService: HorarioService) {}

  ngOnInit(): void {
    this.cargarHorarios();
  }

  cargarHorarios() {
    this.horarioService.getHorariosPorCancha(this.canchaId).subscribe(h => this.horarios = h);
  }

  agregarHorario() {
    this.horarioService.agregarHorario(this.nuevoHorario).subscribe(() => {
      this.nuevoHorario.horaInicio = '';
      this.nuevoHorario.horaFin = '';
      this.cargarHorarios();
    });
  }

  eliminarHorario(id: number) {
    this.horarioService.eliminarHorario(id).subscribe(() => this.cargarHorarios());
  }
}
