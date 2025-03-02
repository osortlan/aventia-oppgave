import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ConfigService {  
  // consider adding config file

  private config: { [key: string]: any } = {
    apiBaseUrl: 'http://localhost:5193',
    notificationMessageDurationMs: 10000,
  };

  setConfig(key: string, value: any): void {
    this.config[key] = value;
  }

  getConfig(key: string): any {
    return this.config[key];
  }
}