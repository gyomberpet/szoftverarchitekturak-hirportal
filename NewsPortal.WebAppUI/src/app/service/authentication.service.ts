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

}
