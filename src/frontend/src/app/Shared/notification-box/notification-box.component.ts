import { Component } from '@angular/core';
import { NotificationService } from '../../Services/notification.service';

@Component({
  selector: 'app-notification-box',
  imports: [],
  templateUrl: './notification-box.component.html',
  styleUrl: './notification-box.component.css'
})
export class NotificationBoxComponent {

  constructor(private notificationService: NotificationService){}

  showMessage = false;
  message = "";
  
  ngOnInit(): void {

    this.notificationService.addReceiveMessageListener((notificationType: string, message: string, data: any) => {
      this.showMessage = true;
      setTimeout(() => {
        this.showMessage = false;
      }, 10000); // 10 seconds
      this.message = message;
    });
  }

  hideMessage(): void {
    this.showMessage = false;
  }
}
