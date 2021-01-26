import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { User} from 'src/app/core/models/usuario';
import { SingInService } from '../../../core/services/sign-in/sign-in.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.scss']
})
export class SignInComponent implements OnInit {
  user: User;
  form: FormGroup;
  loading: Boolean;
  isInvalid: Boolean = false;

  constructor( private formBuilder: FormBuilder,
               private singInService: SingInService,
               private router: Router) { }

  ngOnInit(): void {
    this.buildForm();
  }
  
  private buildForm() {
    this.form = this.formBuilder.group({
      nombre: ["", [Validators.required]],
      apellido: ["", [Validators.required]],
      email: ["", [Validators.required]],
      dni: ["", [Validators.required]],
      cbu: ["", [Validators.required]],
      password: ["", [Validators.required]],
      passconfirm: ["", [Validators.required]]
    });
  }
  
  async newUser(){
    if(this.form.valid){
      this.user ={
      Firstname: this.form.value.nombre,
      Lastname: this.form.value.apellido,
      Email: this.form.value.email,
      Dni: this.form.value.dni,
      Cbu: this.form.value.cbu,
      Password: this.form.value.password
      }
    }
    // console.log(this.user)
    const userNew = (await this.singInService.register(this.user));
    window.alert('Usuario Creado con éxito!');
    this.router.navigateByUrl('/login');
  }
  
  get nombreField() {
    return this.form.get("nombre");
  }
  get apellidoField() {
    return this.form.get("apellido");
  }
  get emailField() {
    return this.form.get("email");
  }
  get dniField() {
    return this.form.get("dni");
  }
  get cbuField() {
    return this.form.get("cbu");
  }
  get passwordField() {
    return this.form.get("password");
  }

  get passwordConfirmField() {
    return this.form.get("passconfirm");
  }

  // Getters Validations
  get nombreFieldValid() {
    return this.nombreField.hasError("required") && this.nombreField.touched;
  }
  get apellidoFieldValid() {
    return this.apellidoField.hasError("required") && this.apellidoField.touched;
  }
  get emailFieldValid() {
    return this.emailField.hasError("required") && this.emailField.touched;
  }
  get dniFieldValid() {
    return this.dniField.hasError("required") && this.dniField.touched;
  }
  get cbuFieldValid() {
    return this.cbuField.hasError("required") && this.cbuField.touched;
  }
  get passwordFieldValid() {
    return this.passwordField.errors && this.passwordField.touched;
  }
  get passwordConfirmFieldValid() {
    return this.passwordConfirmField.errors && this.passwordConfirmField.touched;
  }


}
