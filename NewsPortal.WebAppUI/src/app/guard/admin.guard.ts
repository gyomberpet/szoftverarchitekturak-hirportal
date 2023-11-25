import { CanActivateFn, Router } from '@angular/router';
import {inject } from '@angular/core'
import { jwtDecode } from "jwt-decode";
import { decodedJwtToken } from '../models/decodedJwtToken';
import { AuthorizationService } from '../service/authorization.service';


export const AdminGuard: CanActivateFn = (route, state) => {

  const router = inject(Router);
  const authorization = inject(AuthorizationService);

  if(authorization.checkAdmin())
  {
    return true;
  }
  router.navigate(["/news"])
  return false;
  
};

