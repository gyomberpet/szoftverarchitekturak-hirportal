import { Component } from '@angular/core';
import {NgForm } from '@angular/forms'
import { LoginInfo } from '../../models/loginInfo';
import { UsersService } from '../../service/users.service';
import {Router} from "@angular/router"
import { AuthenticationService } from 'src/app/service/authentication.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  invalidLogin: boolean;
  isEmpty: boolean;
 
  constructor(private usersService : UsersService, private router: Router, private auth : AuthenticationService) {}


  login(form: NgForm)
  {      
    this.invalidLogin = false;
    this.isEmpty = false; 
    var credentials: LoginInfo;
    credentials = new LoginInfo();
    if(this.checkFields(form)){
      this.isEmpty = false;
      credentials.userName = form.value.userName;
      credentials.emailAddress = form.value.emailAddress;
      credentials.password = form.value.password;
      this.usersService.login(credentials).subscribe({
        next: (response) => {
          const token = (<any>response).token;
          localStorage.setItem("jwt",token);
          this.router.navigate(["/news"]);
          this.invalidLogin = false;
        },
        error: (err) => {
          this.invalidLogin = true;
        }
      });    
    }
    else {
      this.isEmpty = true;
    }

  }

  private checkFields(form: NgForm){
    return form.value.userName != "" && form.value.emailAddress != "" && form.value.password != ""
  }
    
}
