import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { StreamListComponent } from '../../Shared/stream-list/stream-list.component';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css',
  imports: [StreamListComponent]
})
export class HomeComponent implements OnInit {
  constructor(private http: HttpClient) {}
  
  ngOnInit(): void {
    
    console.log("api test");
    this.http.get<any>("http://localhost:5193/api/auth/test").subscribe(response => {
      console.log(response);
    });

  }
}
