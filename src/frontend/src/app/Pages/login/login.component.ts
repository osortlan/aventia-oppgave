import { Component } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  standalone: true,
  imports: [FormsModule]
})
export class LoginComponent {

  constructor(private router: Router){}

  onSubmit(form: NgForm) {
    const username = form.value.username;
    const password = form.value.password;

    //console.log('Username:', username);
    //console.log('Password:', password);

    localStorage.setItem("accessToken", "the-token");

    this.router.navigate(['/']);
  }
}