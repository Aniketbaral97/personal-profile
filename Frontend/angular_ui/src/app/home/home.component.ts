import { ChangeDetectorRef, Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EducationComponent } from './components/education/education.component';
import { ExperienceComponent } from './components/experience/experience.component';
import { SkillComponent } from './components/skill/skill.component';
import { SupportUrlComponent } from './components/support-url/support-url.component';
import { PersonalProfileComponent } from './components/personal-profile/personal-profile.component';
import { HeaderComponent } from '../components/header/header.component';
import { animate, style, transition, trigger } from '@angular/animations';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule, EducationComponent, ExperienceComponent, SkillComponent, SupportUrlComponent, PersonalProfileComponent],
  templateUrl: './home.component.html',
  styleUrls: ['../app.component.scss'],
})
export class HomeComponent {
  
}
