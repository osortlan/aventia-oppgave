import { NgClass, NgFor, NgIf } from '@angular/common';
import { Component } from '@angular/core';
import { StreamService } from '../../Services/stream.service';
import { StreamSession } from '../../Model/StreamSession';
import { NotificationService } from '../../Services/notification.service';

@Component({
  selector: 'stream-list',
  imports: [NgFor, NgIf, NgClass],
  templateUrl: './stream-list.component.html',
  styleUrl: './stream-list.component.css'
})
export class StreamListComponent {

  constructor(private streamService: StreamService, private notificationService: NotificationService) {}

  streamSessions: any[] = [];
  isProcessing = false;

  ngOnInit() 
  {
    this.streamService.getStreamSessions().subscribe(response => {
      this.streamSessions = response;
    });

    this.notificationService.addReceiveMessageListener((notificationType: string, message: string, data: StreamSession) => {
      this.streamSessions.push({
        title: data.title,
        isNew: true,
      });
    });
  }

  newStreamSession(): void {
    const newItem = {
      title: "A new stream session",
    };

    this.isProcessing = true;
    this.streamService.createStreamSession(newItem).subscribe((response) => {
      this.isProcessing = false;
    });
  }
}
