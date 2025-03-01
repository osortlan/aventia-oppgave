import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NotificationBoxComponent } from './Shared/notification-box/notification-box.component';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, NotificationBoxComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'frontend';
}
