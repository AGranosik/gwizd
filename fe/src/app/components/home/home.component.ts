import { Component, OnInit } from '@angular/core';
import { QueryService } from 'src/app/http/query.service';
import { DataService } from 'src/app/shared/services/data.service';
import { AuthService } from '@auth0/auth0-angular';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {
  constructor(private queryService: QueryService, public data: DataService, public auth: AuthService, public router : Router) {}
  ngOnInit(): void {
    this.queryService.testConnection().subscribe(console.log);
    this.auth.isAuthenticated$.subscribe(c => {
      if(!c){
        this.router.navigate(['/map']);
      }
    });
  }
}
