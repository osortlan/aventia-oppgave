import { Component } from '@angular/core';
import { StreamListComponent } from '../../Shared/stream-list/stream-list.component';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css',
  imports: [StreamListComponent]
})
export class HomeComponent  {
  constructor() {}
}