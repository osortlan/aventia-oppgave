import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { throwError } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AuthService {

  constructor(private router: Router, private http: HttpClient) { }

  private apiUrl = "http://localhost:5193/api/auth/login";

  isLoggedIn(): boolean
  {
    var accessToken = localStorage.getItem("accessToken");
    if(!accessToken)
    {
      return false;
    }
    return true;
  }

  verifyLoggedInOrRedirect(): void
  {
    var accessToken = localStorage.getItem("accessToken");
    if(!accessToken)
    {
      this.router.navigate(['/login']);
    }
  }

  logIn(username: string, password: string, onSuccess: () => void, onLoginFailed: (response: string) => void): void
  {
    var postBody = {
      username: username,
      password: password,
    };
    this.http.post<any>(this.apiUrl, postBody).subscribe(response => {
      localStorage.setItem("accessToken", response.accessToken)
      onSuccess();
    },
    error => {
      console.log(JSON.stringify(error));
      console.log(error.status);
      if(error.status == 400)
      {
        onLoginFailed(error.error);
      }
      else
      {
        throwError(() => error);
      }
    });
  }
}
