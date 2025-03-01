import { HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { Router } from '@angular/router';
import { catchError, throwError } from 'rxjs';

export const authInterceptor: HttpInterceptorFn = (req, next) => {
  const token = localStorage.getItem('accessToken'); // Or wherever you store the token

  const router = inject(Router);

  // Clone the request to add the new header
  const clonedRequest = req.clone({
    setHeaders: {
      Authorization: `Bearer ${token}`
    }
  });

  return next(clonedRequest).pipe(
    catchError((error) => {
      if (error.status === 401) {
        // Redirect to the login page
        localStorage.removeItem('accessToken');
        router.navigate(['/login'], {queryParams: {errorMessage: "session expired"}});
      }
      return throwError(() => error);
    })
  );
};