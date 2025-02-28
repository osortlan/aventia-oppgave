import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private router: Router) { }

  isLoggedIn()
  {
    return localStorage.getItem("accessToken") != null;
  }

  verifyLoggedIn()
  {
    var accessToken = localStorage.getItem("accessToken");
    if(!accessToken)
    {
      this.router.navigate(['/login']);
      return;
    }
    /*else if()
    {
      // TODO: check expiration
    }*/

    // verification passed
  }
}
