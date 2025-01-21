import { CommonModule } from '@angular/common';
import { AfterViewInit, ChangeDetectorRef, Component, Input, OnInit } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { SupportUrlService } from '../../services/support_url_service';
import { GetSupportUrls } from '../../models/ui/personal_infos';
import { UrlTypes } from '../../models/enums/enums';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  imports:[RouterLink, CommonModule],
  styleUrls: ['./header.component.scss', '../../app.component.scss']
})
export class HeaderComponent implements OnInit {
  token:string |null= null;
  isAuthenticate : boolean=false
  urlFacebook?: string | null;
    urlInstagram?: string | null;
    urlLinkedin?: string | null;
    urlTwitter?: string | null;
    getSupportUrlModel: GetSupportUrls = { supportUrls: [] }
  constructor(private route:Router, private supportUrlService:SupportUrlService){}

  ngOnInit(): void {
    this.fetcSkill();
    this.token = localStorage.getItem('jwt_token');
    console.log('token authenticate:'+ this.token)
    if(this.token != null && this.token != undefined && this.token != '')
    {
      this.isAuthenticate=true;
    }
    else{
      return;
    }

  }

  signOut()
  {
    localStorage.removeItem("jwt_token");
    this.route.navigateByUrl("/login")
  }
  
  fetcSkill() {
      let id = '6f9619ff-8b86-d011-b42d-00cf4fc964ff'
      this.supportUrlService.getSupportUrlByInfoId(id).subscribe((data) => {
        this.getSupportUrlModel = data;
        const facebookUrl = this.getSupportUrlModel.supportUrls.find(url => url.type === UrlTypes.Facebook);
        this.urlFacebook = facebookUrl ? facebookUrl.url : null;
        const instagramUrl = this.getSupportUrlModel.supportUrls.find(url => url.type === UrlTypes.Instagram);
        this.urlInstagram = instagramUrl ? instagramUrl.url : null;
        const linkedInUrl = this.getSupportUrlModel.supportUrls.find(url => url.type === UrlTypes.Linkedin);
        this.urlLinkedin = linkedInUrl ? linkedInUrl.url : null;
        const twitterUrl = this.getSupportUrlModel.supportUrls.find(url => url.type === UrlTypes.Twitter);
        this.urlTwitter = twitterUrl ? twitterUrl.url : null;
      })
    }
}
