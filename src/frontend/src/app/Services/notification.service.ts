import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';
import { throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class NotificationService {

  constructor() 
  { 
    this.hubConnection = new signalR.HubConnectionBuilder()
    .withUrl(this.apiUrl + '/notification')
    .build();
  }

  private apiUrl = "http://localhost:5193";
  private hubConnection: signalR.HubConnection;

  public addReceiveMessageListener(callback: (user: string, message: string) => void): void {
    this.hubConnection
      .start()
      .then(() => console.log('Connection started'))
      .catch(err => throwError(() => err));
    this.hubConnection.on('ReceiveMessage', callback);
  }
}
