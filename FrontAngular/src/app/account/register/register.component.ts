import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { AuthService } from 'src/app/common/auth.service';
import { Player } from 'src/app/models/player';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.sass'],
})
export class RegisterComponent implements OnInit {
  public errorOnForm: boolean = false;
  public errorFormMessage: string = '';
  public registerForm: any;
  public authService: AuthService;

  constructor(
    private formBuilder: FormBuilder,
    public _authService: AuthService
  ) {
    this.authService = _authService;
    this.registerForm = this.formBuilder.group({
      name: ['', Validators.required],
      password: ['', [Validators.required, Validators.minLength(1)]],
      confirmPassword: ['', [Validators.required, Validators.minLength(1)]],
      email: ['', Validators.email],
    });
  }
  ngOnInit(): void {}

  onSubmit(): void {
    this.verifyAndCheckForm();
    this.checkPassword();
    this.errorFormMessage.length > 0
      ? (this.errorOnForm = true)
      : (this.errorOnForm = false);
    if (this.registerForm.valid) {
      console.log(this.registerForm.value);
      const pSend = new Player();
      pSend.name = this.registerForm.value.name;
      pSend.password = this.registerForm.value.password;
      pSend.mail = this.registerForm.value.email;
      this.authService.createUser(pSend).subscribe((o) => console.log(o));
    }
  }

  checkPassword(): void {
    if (
      this.registerForm.value.password !==
      this.registerForm.value.confirmPassword
    ) {
      this.errorOnForm = !this.errorOnForm;
      this.errorFormMessage += 'The two passwords does not match';
    } else {
      if (this.registerForm.value.password.length === 0)
        this.errorFormMessage += 'You need to define a password';
      if (!this.errorOnForm) this.errorOnForm = false;
    }
  }

  verifyAndCheckForm(): void {
    this.errorFormMessage = '';
    let err = false;
    for (let formField in this.registerForm.controls) {
      if (
        this.registerForm.controls[formField].status === 'INVALID' &&
        formField !== 'password' &&
        formField !== 'confirmPassword'
      ) {
        this.errorFormMessage += 'Field ' + formField + ' is invalid<br>';
        if (!err) err = true;
      }
    }
  }
}
