import { CanActivateFn, UrlTree } from '@angular/router';
import { inject } from '@angular/core';
import { AuthService } from './auth.service';

export const authGuard: CanActivateFn = (route, state) => {

  const authService = inject(AuthService);

  authService.verifyLoggedInOrRedirect();

  return true;
};
