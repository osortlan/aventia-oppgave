import { Component } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  standalone: true,
  imports: [FormsModule]
})
export class LoginComponent {
  onSubmit(form: NgForm) {
    const username = form.value.username;
    const password = form.value.password;

    console.log('Username:', username);
    console.log('Password:', password);
  }
}