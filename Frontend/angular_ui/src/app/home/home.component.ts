import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { PersonalInfo } from '../models/ui/personal_infos';
import { PersonalInfoService } from '../services/personalInfo_service';
import { CommonModule } from '@angular/common';
import { EducationComponent } from './components/education/education.component';
import { ExperienceComponent } from './components/experience/experience.component';
import { SkillComponent } from './components/skill/skill.component';
import { EnumService } from '../services/enum_service';
import { SupportUrlComponent } from './components/support-url/support-url.component';

@Component({
  selector: 'app-home',
  standalone:true,
  imports: [CommonModule, EducationComponent, ExperienceComponent, SkillComponent, SupportUrlComponent],
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
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
  ngAfterViewInit(): void {
    const observer = new IntersectionObserver(
      (entries) => {
        entries.forEach((entry) => {
          if (entry.isIntersecting) {
            entry.target.classList.add('visible');
          }
        });
      },
      { threshold: 0.1 } // Trigger when 10% of the section is visible
    );

    const sections = document.querySelectorAll('.section-container');
    sections.forEach((section) => observer.observe(section));
  }
}
