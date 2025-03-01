import { NgFor } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { StreamService } from '../../Services/stream.service';
import { StreamSession } from '../../Model/StreamSession';

@Component({
  selector: 'stream-list',
  imports: [NgFor],
  templateUrl: './stream-list.component.html',
  styleUrl: './stream-list.component.css'
})
export class StreamListComponent implements OnInit {

  constructor(private streamService: StreamService) {}

  streamSessions: StreamSession[] = [];

  ngOnInit() 
  {
    this.streamService.getStreamSessions().subscribe(response => {
      console.log(response);
      this.streamSessions = response;
    });
  }

  newStreamSession() {
    const newItem = {
      title: "I am new here",
    };
    this.streamSessions.push(newItem);
  }
}
