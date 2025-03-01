import { HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { Router } from '@angular/router';
import { catchError, throwError } from 'rxjs';

export const authInterceptor: HttpInterceptorFn = (req, next) => {
  const token = localStorage.getItem('accessToken');

  const router = inject(Router);

  // add access token
  const clonedRequest = req.clone({
    setHeaders: {
      Authorization: `Bearer ${token}`
    }
  });

  return next(clonedRequest).pipe(
    catchError((error) => {
      if (error.status === 401) {
        // Redirect to the login page
        // consider rerplacing this with refresh token logic
        localStorage.removeItem('accessToken');
        router.navigate(['/login'], {queryParams: {errorMessage: "session expired"}});
      }
      return throwError(() => error);
    })
  );
};