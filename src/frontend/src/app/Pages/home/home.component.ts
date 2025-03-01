import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  imports: [],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
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
