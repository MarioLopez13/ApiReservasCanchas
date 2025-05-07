import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = 'https://apireservascanchas.onrender.com/api/Auth';

  constructor(private http: HttpClient) {}

  login(email: string, contrasena: string): Observable<any> {
    return this.http.post(`${this.apiUrl}/login`, {
      email,
      contrasena
    });
  }
  
  
  
}
