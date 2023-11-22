import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { User } from '../models/user';
import { jwtDecode } from 'jwt-decode';
import { decodedJwtToken } from '../models/decodedJwtToken';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  constructor(private jwtHelper: JwtHelperService) {
    
   }
   checkLogin(): Boolean {
      const token = localStorage.getItem("jwt");
      if(token &&!this.jwtHelper.isTokenExpired(token)) {
        return true;
      }
      return false;
   }
   getLoggingUser(): User {
    const token = localStorage.getItem("jwt");
    var decodedToken = new decodedJwtToken();
    var user : User = new User();
    if(token)
    {
      try {
        var decodedToken = jwtDecode<decodedJwtToken>(token);
        user.userName = decodedToken.userName;
        user.emailAddress = decodedToken.emailAdress;
        user.isAdmin = decodedToken.IsAdmin == "True" ? true : false;
      } catch(Error) {
        return user;
      }
    }
    return user;    
   }
}
