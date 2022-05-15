import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { catchError, Observable } from 'rxjs';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiEndPoint: String = "http://localhost:5000/api"
  private baseUrl: String = "users"
  endpoint: any;
  constructor(private http: HttpClient, public router: Router) {}

  createUser(user: User): Observable<any> {
    return this.http.post(`${this.apiEndPoint}/${this.baseUrl}/register`, user);
  }

  logUser(user: User) {
    return this.http.post(`${this.apiEndPoint}/${this.baseUrl}/login`, user).subscribe((o: any) => {
      localStorage.setItem("access_token", o.token);
    });
  }

  getUserToken() {
    return localStorage.getItem('access_token');
  }

  get isUserLogged(): boolean {
    return localStorage.getItem('access_token') !== null;
  }

  logoutUser() {
    localStorage.removeItem('access_token');
  }
}
