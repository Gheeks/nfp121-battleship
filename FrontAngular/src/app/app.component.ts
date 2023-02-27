import { Component } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { ColDef } from 'ag-grid-community';
import { AuthService } from './common/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  public authService: AuthService;
  title = 'Battleship';
  constructor(
    private jwtHelper: JwtHelperService,
    private _authService: AuthService
  ) {
    this.authService = _authService;
  }

  isUserAuthenticated = (): boolean => {
    const token = localStorage.getItem('jwt');
    if (token && !this.jwtHelper.isTokenExpired(token)) {
      return true;
    }
    return false;
  };

  getUserName = (): string => {
    return this.authService.parseJwt(localStorage.getItem('jwt')).name;
  };
}
