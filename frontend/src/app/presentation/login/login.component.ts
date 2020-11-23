import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/application/auth/auth.service';

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
    private router: Router,
    private authService : AuthService
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
    this.loading = true;

    if (this.form.valid) {
      this.authService.login(this.form.value)
        .subscribe(
          res => {
            console.log('LOGIN RESPONSE',res);
          },
          err => {
            console.log('LOGIN ERROR',err);
          },
          () => this.router.navigateByUrl("/home")
        );
    } else {

      this.form.markAllAsTouched();
      this.loading = false;
    }
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
