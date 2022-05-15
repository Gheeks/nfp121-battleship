import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.sass']
})
export class AccountComponent implements OnInit {
  constructor(private formBuilder: FormBuilder) {

  }

  ngOnInit(): void {
  }

}
