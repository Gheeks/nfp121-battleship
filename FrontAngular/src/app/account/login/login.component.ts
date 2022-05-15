import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.sass']
})
export class LoginComponent implements OnInit {
  public errorOnForm: boolean = false;
  public errorFormMessage: string = "";
  public loginForm: any;

  constructor(private formBuilder: FormBuilder) {
    this.loginForm = this.formBuilder.group({
      name: ['', Validators.required],
      password: ['', [Validators.required, Validators.minLength(1)]],
    });
  }
  ngOnInit(): void {
  }

  onSubmit(): void {
    this.verifyAndCheckForm();
    this.errorFormMessage.length > 0 ? this.errorOnForm = true : this.errorOnForm = false;
    if(this.loginForm.valid){
      console.log('ok');
    }
  }

  verifyAndCheckForm(): void {
    this.errorFormMessage = "";
    let err = false;
    for (let formField in this.loginForm.controls) {
      if (this.loginForm.controls[formField].status === "INVALID"){
        this.errorFormMessage += "Field " + formField + " is invalid<br>"
        if (!err) err = true;
      }
    }
  }
}
