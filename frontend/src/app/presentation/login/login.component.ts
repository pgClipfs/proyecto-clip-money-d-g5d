import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserRegister } from 'src/app/core/models/usuario';
import { AuthService } from 'src/app/core/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  user: UserRegister;
  form: FormGroup;
  loading: Boolean;
  isInvalid: Boolean = false;

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private authService: AuthService
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

  async send() {

    if (this.form.valid){
      this.user = {
        Email: this.form.value.name,
        Password: this.form.value.password
      }
      const token = (await this.authService.login(this.user)).UserToken;
      if (token !== 'Usuario y/o contraseña incorrectos.'){
        this.authService.setCurrentUser('eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiIxIiwiZW1haWwiOiJ2YWxlbnRpbnBhcmlzOTdAZ21haWwuY29tIiwibmFtZSI6InZhbGVudGluIiwibGFzdG5hbWUiOiJwYXJpcyIsImV4cCI6MTYxMTcwNTg2NSwiaXNzIjoieW91cmRvbWFpbi5jb20ifQ.VcVFhF_mwDWe8NqgneW0_2crl41aiQvcZvyyytXzisc');
        this.router.navigateByUrl("/home")
      }
      else{
        alert(token);
      }
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

  onNavigate(){
    this.router.navigateByUrl("sign-in");
  }

}
