import { Injectable } from '@angular/core';
import { decodedJwtToken } from '../models/decodedJwtToken';
import { jwtDecode } from 'jwt-decode';


@Injectable({
  providedIn: 'root'
})
export class AuthorizationService {

  constructor() { }


  checkAdmin(){
    const token = localStorage.getItem("jwt");
    var decodedToken = new decodedJwtToken();
    if(token)
    {
      try {
        var decodedToken = jwtDecode<decodedJwtToken>(token);
      } catch(Error) {
        return false;
      }
    }
    if(decodedToken.IsAdmin == "True")
    {
      return true;
    }
    return false;
  }

}
