import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { GetSupportUrls, PersonalInfo } from '../../../models/ui/personal_infos';
import { PersonalInfoService } from '../../../services/personalInfo_service';
import { EnumService } from '../../../services/enum_service';
import { animate, style, transition, trigger } from '@angular/animations';
import { SupportUrlService } from '../../../services/support_url_service';
import { UrlTypes } from '../../../models/enums/enums';

@Component({
  selector: 'app-personal-profile',
  imports: [CommonModule],
  templateUrl: './personal-profile.component.html',
  styleUrls: ['../../../app.component.scss', './personal-profile.component.scss'],
  animations: [
    trigger('fadeIn', [
      transition(':enter', [
        style({ opacity: 0 }), // initial state
        animate('500ms 200ms', style({ opacity: 1 })), // animation
      ]),
    ]),
  ],
})
export class PersonalProfileComponent {
  personalInfo?: PersonalInfo
  urlFacebook?: string | null;
  urlInstagram?: string | null;
  urlLinkedin?: string | null;
  urlTwitter?: string | null;
  getSupportUrlModel: GetSupportUrls = { supportUrls: [] }
  constructor(private personalInfoService: PersonalInfoService, private enumService: EnumService, private supportUrlService: SupportUrlService) { }
  ngOnInit(): void {
    this.fetchData();
    this.fetcSkill();
  }
  public fetchData() {
    this.personalInfoService.getPersonalInfoById('6f9619ff-8b86-d011-b42d-00cf4fc964ff').subscribe((data) => {
      this.personalInfo = data;
    });
  }
  getGenderEnumKey(gender: number) {
    return this.enumService.getGenderEnumKey(gender)
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
