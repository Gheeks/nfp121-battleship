import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthenticatedResponse } from '../models/authenticated-response';
import { Player } from '../models/player';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private apiEndPoint: String = 'https://localhost:7216';
  private baseUrl: String = 'Player';
  endpoint: any;

  constructor(private http: HttpClient, public router: Router) {}

  createUser(user: Player): Observable<any> {
    return this.http.post(
      `${this.apiEndPoint}/${this.baseUrl}/CreateNewUser`,
      user
    );
  }

  logUser(user: Player): Observable<any> {
    return this.http.post<AuthenticatedResponse>(
      `${this.apiEndPoint}/${this.baseUrl}/Login`,
      user,
      {
        headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
      }
    );
  }

  getUserToken() {
    return localStorage.getItem('jwt');
  }

  get isUserLogged(): boolean {
    return localStorage.getItem('jwt') !== null;
  }

  logoutUser() {
    localStorage.removeItem('jwt');
    this.router.navigate(['login']);
  }

  parseJwt(token) {
    var base64Url = token.split('.')[1];
    var base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
    var jsonPayload = decodeURIComponent(
      atob(base64)
        .split('')
        .map(function (c) {
          return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
        })
        .join('')
    );

    return JSON.parse(jsonPayload);
  }
}
