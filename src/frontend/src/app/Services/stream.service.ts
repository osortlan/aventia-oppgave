import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { StreamSession } from '../Model/StreamSession';

@Injectable({
  providedIn: 'root'
})
export class StreamService {

  constructor(private http: HttpClient) { }

  private apiUrl = "http://localhost:5193";

  getStreamSessions(): Observable<StreamSession[]>
  {
    return this.http.get<{ streamSessions: StreamSession[]}>(this.apiUrl + "/api/stream").pipe(
      map(response => response.streamSessions)
    );
  }
}
