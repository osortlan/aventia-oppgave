import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { throwError } from 'rxjs';
import { ConfigService } from '../Services/config.service';

@Injectable({
  providedIn: 'root',
})
export class AuthService {

  constructor(private config: ConfigService, private router: Router, private http: HttpClient) { }

  isLoggedIn(): boolean
  {
    var accessToken = localStorage.getItem("accessToken");
    if(!accessToken)
    {
      return false;
    }
    return true;
  }

  getLoggedInUsername(): string
  {
    var accessToken = localStorage.getItem("accessToken");
    if(!accessToken)
    {
      return "";
    }

    const payload = JSON.parse(atob(accessToken.split('.')[1]));
    
    return payload.sub;
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
    this.http.post<any>(this.config.getConfig('apiBaseUrl') + "/api/auth/login", postBody).subscribe(response => {
      localStorage.setItem("accessToken", response.accessToken)
      onSuccess();
    },
    error => {
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