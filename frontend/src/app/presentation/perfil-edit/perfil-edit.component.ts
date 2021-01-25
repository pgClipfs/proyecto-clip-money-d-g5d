import { Component, OnInit } from '@angular/core';
import { User, UserRegister } from '../../core/models/usuario';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { EditPerfilService } from '../../core/services/edit-perfil/edit-perfil.service';
import { EditarPerfil } from '../../core/models/editarPerfil';
import { Cuenta } from '../../core/models/cuenta';
import { AuthService } from 'src/app/core/services/auth.service';

@Component({
  selector: 'app-perfil-edit',
  templateUrl: './perfil-edit.component.html',
  styleUrls: ['./perfil-edit.component.scss']
})
export class PerfilEditComponent implements OnInit {
  
  datosEditados:EditarPerfil
  currentUser: User;
  perfilEditado:User;
  form: FormGroup;
  loading: Boolean;
  isInvalid: Boolean = false;

  constructor( private formBuilder: FormBuilder,
               private editPerfilService: EditPerfilService,
               private authService: AuthService) { }

  ngOnInit(): void {
    this.buildForm();
    this.currentUser = this.authService.getCurrentUser();
  }
  
  private buildForm() {
    this.form = this.formBuilder.group({
      email: ["", [Validators.required]],
      password: ["", [Validators.required]],
      passconfirm: ["", [Validators.required]]
    });
  }
  
  async editarPerfil(){
    if(this.form.value.passconfirm == this.form.value.password){
      if(this.form.valid){
        console.log("this.form.valid")
        this.datosEditados ={
          Id: this.currentUser.Id,
          Email: this.form.value.email,
          Password: this.form.value.password
        };
        
      }
      
    }
    this.perfilEditado = (await this.editPerfilService.putEditPerfil(this.datosEditados)).Object

    console.log("editar perfil datos")
    console.log(this.editarPerfil)
  }
  
  get emailField() {
    return this.form.get("email");
  }
  get passwordField() {
    return this.form.get("password");
  }
  get passwordConfirmField() {
    return this.form.get("passconfirm");
  }

  // Getters Validations
  get emailFieldValid() {
    return this.emailField.hasError("required") && this.emailField.touched;
  }
  get passwordFieldValid() {
    return this.passwordField.errors && this.passwordField.touched;
  }
  get passwordConfirmFieldValid() {
    return this.passwordConfirmField.errors && this.passwordConfirmField.touched;
  }
}
