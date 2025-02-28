import { Component } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { AuthService } from '../../Auth/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  standalone: true,
  imports: [FormsModule]
})
export class LoginComponent {

  constructor(private authService: AuthService, private router: Router){}

  isProcessing = false;

  onSubmit(form: NgForm) {
    this.isProcessing = true;

    const username = form.value.username;
    const password = form.value.password;

    this.authService.logIn(username, password, () => {
      this.router.navigate(['/']);
    }, () => {
      this.isProcessing = false;
    });

    //console.log('Username:', username);
    //console.log('Password:', password);
    //localStorage.setItem("accessToken", "the-token");
    
  }
}