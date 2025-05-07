import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { LoginComponent } from './pages/login/login.component';
import { CanchasComponent } from './pages/canchas/canchas.component';
import { HorariosComponent } from './pages/horarios/horarios.component';
import { MenuComponent } from './pages/menu/menu.component';
import { ReservasComponent } from './pages/reservas/reservas.component';
import { HistorialReservasComponent } from './pages/historial-reservas/historial-reservas.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    CanchasComponent,
    HorariosComponent,
    MenuComponent,
    ReservasComponent,
    HistorialReservasComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
