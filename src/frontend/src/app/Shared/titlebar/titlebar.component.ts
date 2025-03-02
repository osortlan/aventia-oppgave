import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-titlebar',
  imports: [],
  templateUrl: './titlebar.component.html',
  styleUrl: './titlebar.component.css'
})
export class TitlebarComponent 
{
  @Input() title = ""
}
