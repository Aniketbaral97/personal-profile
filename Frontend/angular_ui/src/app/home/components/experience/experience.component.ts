import { Component, OnInit } from '@angular/core';
import { ExperienceService } from '../../../services/experience_service';
import { GetExperiences } from '../../../models/ui/personal_infos';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-experience',
  imports: [CommonModule],
  templateUrl: './experience.component.html',
  styleUrl: './experience.component.scss'
})
export class ExperienceComponent implements OnInit{
  experiences : GetExperiences = {experiences:[]} 
  constructor(private experienceService: ExperienceService){}
  ngOnInit(): void {
    this.fetchData();
  }
  fetchData(){
    this.experienceService.getExperienceByInfoId('6f9619ff-8b86-d011-b42d-00cf4fc964ff').subscribe((data)=>{
      this.experiences =data;
    })
  }
}
