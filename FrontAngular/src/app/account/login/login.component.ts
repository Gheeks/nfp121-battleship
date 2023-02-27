import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/common/auth.service';
import { AuthenticatedResponse } from 'src/app/models/authenticated-response';
import { Player } from 'src/app/models/player';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.sass'],
})
export class LoginComponent implements OnInit {
  public errorOnForm: boolean = false;
  public errorFormMessage: string = '';
  public loginForm: any;
  public authService: AuthService;
  public invalidLogin: boolean = true;

  constructor(
    private formBuilder: FormBuilder,
    public _authService: AuthService,
    public router: Router
  ) {
    this.authService = _authService;
    this.loginForm = this.formBuilder.group({
      name: ['', Validators.required],
      password: ['', [Validators.required, Validators.minLength(1)]],
    });
  }
  ngOnInit(): void {}

  onSubmit(): void {
    this.verifyAndCheckForm();
    this.errorFormMessage.length > 0
      ? (this.errorOnForm = true)
      : (this.errorOnForm = false);
    if (this.loginForm.valid) {
      const pSend = new Player();
      pSend.name = this.loginForm.value.name;
      pSend.password = this.loginForm.value.password;
      this.authService.logUser(pSend).subscribe({
        next: (response: AuthenticatedResponse) => {
          const token = response.token;
          localStorage.setItem('jwt', token);
          this.invalidLogin = false;
          this.router.navigate(['grid']);
        },
        error: (err: HttpErrorResponse) => (this.invalidLogin = true),
      });
    }
  }

  verifyAndCheckForm(): void {
    this.errorFormMessage = '';
    let err = false;
    for (let formField in this.loginForm.controls) {
      if (this.loginForm.controls[formField].status === 'INVALID') {
        this.errorFormMessage += 'Field ' + formField + ' is invalid<br>';
        if (!err) err = true;
      }
    }
  }
}
