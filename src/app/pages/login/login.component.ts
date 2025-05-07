import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';

@Component({
  standalone :false,
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  email: string = '';
  contrasena: string = '';

  constructor(private auth: AuthService, private router: Router) {}

  login() {
    this.auth.login(this.email, this.contrasena).subscribe(
      (usuario) => {
        localStorage.setItem('usuario', JSON.stringify(usuario));
        alert('Bienvenido ' + usuario.nombre);
        this.router.navigate(['/menu']);
 // Redirige al componente de canchas
      },
      (error) => {
        alert('Credenciales incorrectas');
      }
    );
  }
  
}


