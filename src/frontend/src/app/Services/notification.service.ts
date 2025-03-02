import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';
import { throwError } from 'rxjs';
import { ConfigService } from './config.service';

@Injectable({
  providedIn: 'root'
})
export class NotificationService {

  constructor(private config: ConfigService) 
  { 
    this.hubConnection = new signalR.HubConnectionBuilder()
    .withUrl(this.config.getConfig('apiBaseUrl') + '/notification')
    .build();
  }

  private hubConnection: signalR.HubConnection;

  public addReceiveMessageListener(callback: (notificationType: string, message: string, data: any) => void): void {
    this.hubConnection
      .start()
      .then(() => console.log('Connection started'))
      .catch(err => throwError(() => err));
    this.hubConnection.on('ReceiveMessage', callback);
  }
}
