import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { PersonalInfo } from '../../../models/ui/personal_infos';
import { PersonalInfoService } from '../../../services/personalInfo_service';
import { EnumService } from '../../../services/enum_service';
import { animate, style, transition, trigger } from '@angular/animations';

@Component({
  selector: 'app-personal-profile',
  imports: [CommonModule],
  templateUrl: './personal-profile.component.html',
  styleUrls: ['../../../app.component.scss'],
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
  personalInfo? : PersonalInfo
  constructor(private personalInfoService: PersonalInfoService, private enumService : EnumService) { }
  ngOnInit(): void {
    this.fetchData();
  }
  public fetchData() {
    this.personalInfoService.getPersonalInfoById('6f9619ff-8b86-d011-b42d-00cf4fc964ff').subscribe((data) => {
      this.personalInfo = data;
   });
  }
  getGenderEnumKey(gender:number){
    return this.enumService.getGenderEnumKey(gender)
  }

}
