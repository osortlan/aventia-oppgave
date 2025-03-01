import { Component, OnInit } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { AuthService } from '../../Auth/auth.service';
import { ActivatedRoute, Router } from '@angular/router';
import { NgIf } from '@angular/common';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  standalone: true,
  imports: [FormsModule, NgIf]
})
export class LoginComponent implements OnInit {

  constructor(private authService: AuthService, private router: Router, private activateRoute: ActivatedRoute ){}

  isProcessing = false;
  errorMessage = "";

  ngOnInit(): void {
    this.activateRoute.queryParams.subscribe((params) => {
      this.errorMessage = params['errorMessage'];
    });
  }

  onSubmit(form: NgForm) {
    this.errorMessage = "";
    this.isProcessing = true;

    const username = form.value.username;
    const password = form.value.password;

    this.authService.logIn(username, password, () => {
      this.isProcessing = false;
      this.router.navigate(['/']);
    }, (errorMessage: string) => {
      this.isProcessing = false;
      this.errorMessage = errorMessage;
    });
  }
}