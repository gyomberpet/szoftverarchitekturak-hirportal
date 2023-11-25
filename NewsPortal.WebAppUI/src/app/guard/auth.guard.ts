import { CanActivateFn, Router } from '@angular/router';
import {inject } from '@angular/core'
import { AuthenticationService } from '../service/authentication.service';

export const AuthGuard: CanActivateFn = (route, state) => {

  const authService = inject(AuthenticationService);
  const router = inject(Router);
  
  if(authService.checkLogin())
  {
    return true;
  }
  router.navigate(["/login"]);
  return false;
};
