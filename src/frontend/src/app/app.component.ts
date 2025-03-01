import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NotificationBoxComponent } from './Shared/notification-box/notification-box.component';
import { TitlebarComponent } from './Shared/titlebar/titlebar.component';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, NotificationBoxComponent, TitlebarComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'frontend';
}
