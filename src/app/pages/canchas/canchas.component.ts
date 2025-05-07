import { Component, OnInit } from '@angular/core';
import { CanchaService } from '../../services/cancha.service';
import { HorarioService } from '../../services/horario.service';

@Component({
  standalone :false,
  selector: 'app-canchas',
  templateUrl: './canchas.component.html',
  styleUrls: ['./canchas.component.css']
})
export class CanchasComponent implements OnInit {
  canchas: any[] = [];
  horariosPorCancha: { [key: number]: any[] } = {};
  mostrarHorarios: { [key: number]: boolean } = {};

  nuevaCancha = {
    nombre: '',
    tipo: '',
    ubicacion: ''
  };

  nuevoHorario = {
    horaInicio: '',
    horaFin: '',
    disponible: true
  };

  constructor(private canchaService: CanchaService, private horarioService: HorarioService) {}

  ngOnInit(): void {
    this.obtenerCanchas();
  }

  obtenerCanchas() {
    this.canchaService.getCanchas().subscribe(data => {
      this.canchas = data;
    });
  }

  agregarCancha() {
    this.canchaService.createCancha(this.nuevaCancha).subscribe(() => {
      this.nuevaCancha = { nombre: '', tipo: '', ubicacion: '' };
      this.obtenerCanchas();
    });
  }

  eliminarCancha(id: number) {
    this.canchaService.deleteCancha(id).subscribe(() => this.obtenerCanchas());
  }

  toggleHorarios(canchaId: number) {
    if (!this.mostrarHorarios[canchaId]) {
      this.horarioService.getHorariosPorCancha(canchaId).subscribe(h => {
        this.horariosPorCancha[canchaId] = h;
        this.mostrarHorarios[canchaId] = true;
      });
    } else {
      this.mostrarHorarios[canchaId] = false;
    }
  }

  agregarHorario(canchaId: number) {
    const nuevo = {
      canchaId,
      horaInicio: this.nuevoHorario.horaInicio,
      horaFin: this.nuevoHorario.horaFin,
      disponible: true
    };

    this.horarioService.agregarHorario(nuevo).subscribe(() => {
      this.nuevoHorario.horaInicio = '';
      this.nuevoHorario.horaFin = '';
      this.toggleHorarios(canchaId);
      this.toggleHorarios(canchaId); // recargar
    });
  }

  eliminarHorario(horarioId: number, canchaId: number) {
    this.horarioService.eliminarHorario(horarioId).subscribe(() => {
      this.toggleHorarios(canchaId);
      this.toggleHorarios(canchaId);
    });
  }
}
