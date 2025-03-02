import { Component } from '@angular/core';
import { AuthService } from '../../Auth/auth.service';

@Component({
  selector: 'app-titlebar',
  imports: [],
  templateUrl: './titlebar.component.html',
  styleUrl: './titlebar.component.css'
})
export class TitlebarComponent 
{
  constructor(private authService: AuthService)
  {
    this.loggedInUsername = authService.getLoggedInUsername();
  }
  
  loggedInUsername = "";
}
