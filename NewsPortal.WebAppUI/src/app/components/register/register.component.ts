import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { LoginInfo } from '../../models/loginInfo';
import { UsersService } from '../../service/users.service';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/service/authentication.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  invalidRegister: boolean;
  isEmpty: boolean;


  constructor(private usersService : UsersService, private router: Router, private auth: AuthenticationService) {}

  register(form: NgForm) {
    this.invalidRegister = false;
    this.isEmpty = false; 
    var credentials: LoginInfo;
    credentials = new LoginInfo();
    if(this.checkFields(form)){
      this.isEmpty = false;
      credentials.userName = form.value.userName;
      credentials.emailAddress = form.value.emailAddress;
      credentials.password = form.value.password;
      this.usersService.register(credentials).subscribe({
        next: (response) => {
          const token = (<any>response).token;
          localStorage.setItem("jwt",token);
          this.router.navigate(["/news"]);
          this.invalidRegister = false;
        },
        error: (err) => {
          this.invalidRegister = true;
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
