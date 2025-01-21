import { CommonModule } from '@angular/common';
import { AfterViewInit, ChangeDetectorRef, Component, Input, OnInit } from '@angular/core';
import { Router, RouterLink } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  imports:[RouterLink, CommonModule],
  styleUrls: ['./header.component.scss', '../../app.component.scss']
})
export class HeaderComponent implements OnInit {
  token:string |null= null;
  isAuthenticate : boolean=false
  constructor(private route:Router){}

  ngOnInit(): void {
    this.token = localStorage.getItem('jwt_token');
    console.log('token authenticate:'+ this.token)
    if(this.token != null && this.token != undefined && this.token != '')
    {
      this.isAuthenticate=true;
    }
  }

  signOut()
  {
    localStorage.removeItem("jwt_token");
    this.route.navigateByUrl("/login")
  }

}
