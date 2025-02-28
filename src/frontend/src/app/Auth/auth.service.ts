import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { catchError } from 'rxjs';

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
    /*else if()
    {

    }*/
    return true;
  }

  verifyLoggedInOrRedirect(): void
  {
    var accessToken = localStorage.getItem("accessToken");
    if(!accessToken)
    {
      this.router.navigate(['/login']);
    }
    /*else if()
    {
      // TODO: check expiration
    }*/

    // verification passed
  }

  logIn(username: string, password: string, onSuccess: () => void, onError: (response: string) => void): void
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
      if(error.status == 403)
      {
        onError("Wrong username or password");
      }
      else
      {
        throw new Error('Unexpected error from API: ' + error.error);
      }
    });
  }
}
