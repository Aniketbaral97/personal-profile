import { AfterViewInit, ChangeDetectorRef,PLATFORM_ID, Component, ElementRef, Inject, ViewChild } from '@angular/core';
import { CommonModule, isPlatformBrowser } from '@angular/common';
import { EducationComponent } from './components/education/education.component';
import { ExperienceComponent } from './components/experience/experience.component';
import { SkillComponent } from './components/skill/skill.component';
import { SupportUrlComponent } from './components/support-url/support-url.component';
import { PersonalProfileComponent } from './components/personal-profile/personal-profile.component';
import { HeaderComponent } from '../components/header/header.component';
import { animate, keyframes, style, transition, trigger } from '@angular/animations';
import { ReferenceComponent } from './components/reference/reference.component';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule, HeaderComponent, EducationComponent, ExperienceComponent, SkillComponent, SupportUrlComponent, PersonalProfileComponent, ReferenceComponent],
  templateUrl: './home.component.html',
  styleUrls: ['../app.component.scss'],
  animations: [
    trigger('zoomIn', [
      transition(':enter', [
        style({ opacity: 0, transform: 'scale(0.3)', visibility: 'hidden' }),
        animate('0.8s ease-out', keyframes([
          style({ opacity: 0, transform: 'scale(0.3)', offset: 0 }), 
          style({ opacity: 0.5, transform: 'scale(0.7)', offset: 0.5 }),
          style({ opacity: 1, transform: 'scale(1)', visibility: 'visible', offset: 1 })
        ]))
      ])
    ])
  ]
})
export class HomeComponent implements AfterViewInit {
  
  @ViewChild('about') aboutElement?: ElementRef;
  @ViewChild('education') educationElement?: ElementRef;
  @ViewChild('experience') experienceElement?: ElementRef;
  @ViewChild('skill') skillElement?: ElementRef;
  @ViewChild('supporturl') supportUrlElement?: ElementRef;
  @ViewChild('reference') referenceElement?: ElementRef;
  constructor(@Inject(PLATFORM_ID) private platformId: object){}
  isVisible: { [key in 'about' | 'education' | 'experience' | 'skill' | 'supporturl' | 'reference']: boolean } = {
    about: false,
    education: false,
    experience: false,
    skill: false,
    supporturl: false,
    reference:false,
  };

  ngAfterViewInit() {
    if (isPlatformBrowser(this.platformId)) {
      this.createObserver();
    }
  }

  createObserver() {
    if (typeof IntersectionObserver === 'undefined') {
      console.warn('IntersectionObserver is not supported in this environment.');
      return;
    }
    const observer = new IntersectionObserver((entries) => {
      entries.forEach(entry => {
        if (entry.isIntersecting) {
          const id = entry.target.id as keyof typeof this.isVisible; // Ensure id matches the keys
          this.isVisible[id] = true;
        }
      });
    }, { threshold: 0.5 });
  
    observer.observe(this.aboutElement?.nativeElement);
    observer.observe(this.educationElement?.nativeElement);
    observer.observe(this.experienceElement?.nativeElement);
    observer.observe(this.skillElement?.nativeElement);
    observer.observe(this.supportUrlElement?.nativeElement);
    observer.observe(this.referenceElement?.nativeElement);
  }
}
