import { NgFor, NgIf } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { StreamService } from '../../Services/stream.service';
import { StreamSession } from '../../Model/StreamSession';

@Component({
  selector: 'stream-list',
  imports: [NgFor, NgIf],
  templateUrl: './stream-list.component.html',
  styleUrl: './stream-list.component.css'
})
export class StreamListComponent implements OnInit {

  constructor(private streamService: StreamService) {}

  streamSessions: StreamSession[] = [];
  isProcessing = false;

  ngOnInit()
  {
    this.streamService.getStreamSessions().subscribe(response => {
      this.streamSessions = response;
    });
  }

  newStreamSession() {
    const newItem: StreamSession = {
      title: "I am new here",
    };

    this.isProcessing = true;
    this.streamService.createStreamSession(newItem).subscribe((response) => {
      this.isProcessing = false;
    });
  }
}
