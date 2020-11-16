import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  form: FormGroup;
  loading: Boolean;
  isInvalid: Boolean = false;

  constructor(
    private formBuilder: FormBuilder,
    private router: Router
    ) { }

  ngOnInit(): void {
    this.buildForm();
  }

  private buildForm() {
    this.form = this.formBuilder.group({
      name: ["", [Validators.required]],
      password: ["", [Validators.required]]
    });
  }

  send(event: Event) {

    event.preventDefault();
    this.router.navigateByUrl("/home")
    // TODO: Validate user
    // this.isInvalid
    // this.loading
  }

  // Getters
  get nameField() {
    return this.form.get("name");
  }
  get passwordField() {
    return this.form.get("password");
  }

  // Getters Validations
  get nameFieldValid() {
    return this.nameField.hasError("required") && this.nameField.touched;
  }
  get passwordFieldValid() {
    return this.passwordField.errors && this.passwordField.touched;
  }

}
