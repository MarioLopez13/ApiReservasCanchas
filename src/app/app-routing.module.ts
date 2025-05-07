import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './pages/login/login.component';
import { CanchasComponent } from './pages/canchas/canchas.component';
import { HorariosComponent } from './pages/horarios/horarios.component';
import { MenuComponent } from './pages/menu/menu.component'; // 👈 Importa el nuevo

import { ReservasComponent } from './pages/reservas/reservas.component';

import { HistorialReservasComponent } from './pages/historial-reservas/historial-reservas.component';

const routes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'login', component: LoginComponent },
  { path: 'menu', component: MenuComponent },
  { path: 'canchas', component: CanchasComponent },
  { path: 'horarios', component: HorariosComponent },
  { path: 'reservas', component: ReservasComponent },
  { path: 'historial', component: HistorialReservasComponent } // ✅ nueva ruta
];



@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
