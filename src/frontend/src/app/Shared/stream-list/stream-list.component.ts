import { NgFor } from '@angular/common';
import { Component } from '@angular/core';

@Component({
  selector: 'stream-list',
  imports: [NgFor],
  templateUrl: './stream-list.component.html',
  styleUrl: './stream-list.component.css'
})
export class StreamListComponent {

  streamSessions: any[] = [{ title: "kjeks"}, { title: "kake" }, { title: "bjørn"}]

  newStreamSession() {
    const newItem = {
      title: "I am new here",
    };
    this.streamSessions.push(newItem);
  }
}
