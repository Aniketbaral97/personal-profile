import { AfterViewInit, ChangeDetectorRef, Component, Input } from '@angular/core';
import { Router, RouterLink } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  imports:[RouterLink],
  styleUrls: ['./header.component.scss', '../../app.component.scss']
})
export class HeaderComponent implements AfterViewInit {
  token:string |null= null;
  isAuthenticate : boolean=false
  constructor(private route:Router){}

  ngAfterViewInit(): void {
    this.token = localStorage.getItem('jwt_token');
    if(this.token != null && this.token != undefined)
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
