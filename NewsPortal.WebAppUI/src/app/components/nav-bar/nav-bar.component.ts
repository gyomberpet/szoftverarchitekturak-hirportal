import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { jwtDecode } from 'jwt-decode';
import { decodedJwtToken } from 'src/app/models/decodedJwtToken';
import { User } from 'src/app/models/user';
import { AuthenticationService } from 'src/app/service/authentication.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent {
    isLogged : Boolean = false;
    isNotLogged : Boolean = !this.isLogged;
    isAdminUser : Boolean = false;
    userNameText : string = "";


   constructor(private jwtHelper : JwtHelperService, private router : Router, private auth: AuthenticationService) {

   }

   ngOnInit() {
    this.router.events.subscribe(event => {
      if (event.constructor.name === "NavigationEnd") {
        this.isLogged = this.auth.checkLogin();
        this.isNotLogged = !this.isLogged;
        var user = this.auth.getLoggingUser();
        if(user.userName != null){
             this.userNameText = user.userName;
        }
        if(user.isAdmin != null) {
            this.isAdminUser = user.isAdmin;
        }
      }
    })
  }

  signOut(){
    localStorage.removeItem("jwt");
    this.router.navigate(["/login"]);
  }

}
