import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { StreamSession } from '../Model/StreamSession';
import { ConfigService } from './config.service';

@Injectable({
  providedIn: 'root'
})
export class StreamService {

  constructor(private config: ConfigService, private http: HttpClient) { }

  getStreamSessions(): Observable<StreamSession[]>
  {
    return this.http.get<{ streamSessions: StreamSession[]}>(this.config.getConfig('apiBaseUrl') + "/api/stream").pipe(
      map(response => response.streamSessions)
    );
  }

  createStreamSession(newSessionData: StreamSession): Observable<void>
  {
    return this.http.post(this.config.getConfig('apiBaseUrl') + "/api/stream", {
      title: newSessionData.title
    }).pipe(map(response => undefined));
  }
}