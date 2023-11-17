import { Component } from '@angular/core';
import {NgForm } from '@angular/forms'
import { LoginInfo } from '../models/loginInfo';
import { UsersService } from '../service/users.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  invalidLogin: boolean;
  credentials: LoginInfo;

  constructor(private usersService : UsersService) {}


  login(form: NgForm)
  {       
        this.credentials = new LoginInfo();
         this.credentials.userName = form.value.userName;
         this.credentials.emailAddress = form.value.emailAddress;
         this.credentials.password = form.value.password;

         this.usersService.login(this.credentials).subscribe(
          response => {
            const token = (<any>response).token;
            localStorage.setItem("jwt",token);
      
            this.invalidLogin = false;
          }, err => {
            this.invalidLogin = true;
          }
         )
  }

  


}
