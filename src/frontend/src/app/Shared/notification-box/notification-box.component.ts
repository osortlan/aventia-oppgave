import { Component } from '@angular/core';
import { NotificationService } from '../../Services/notification.service';
import { ConfigService } from '../../Services/config.service';

@Component({
  selector: 'app-notification-box',
  imports: [],
  templateUrl: './notification-box.component.html',
  styleUrl: './notification-box.component.css'
})
export class NotificationBoxComponent {

  constructor(private config: ConfigService, private notificationService: NotificationService){}

  showMessage = false;
  message = "";
  
  ngOnInit(): void {

    this.notificationService.addReceiveMessageListener((notificationType: string, message: string, data: any) => {
      this.showMessage = true;
      setTimeout(() => {
        this.showMessage = false;
        this.message = "";
      }, this.config.getConfig('notificationMessageDurationMs')); // 10 seconds
      this.message = message;
    });
  }

  hideMessage(): void {
    this.showMessage = false;
  }
}
