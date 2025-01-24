import { Component, OnInit } from '@angular/core';
import { ExperienceService } from '../../../services/experience_service';
import { GetExperiences } from '../../../models/ui/personal_infos';
import { CommonModule } from '@angular/common';
import { PersonalInfoService } from '../../../services/personalInfo_service';

@Component({
  selector: 'app-experience',
  imports: [CommonModule],
  templateUrl: './experience.component.html',
  styleUrls: ['./experience.component.scss', '../../../app.component.scss']
})
export class ExperienceComponent implements OnInit{
  experiences : GetExperiences = {experiences:[]} 
  infoId: string="00000000-0000-0000-0000-000000000000"
  constructor(private experienceService: ExperienceService, private personalInfoService: PersonalInfoService){}
  ngOnInit(): void {
    this.fetchMainInfoId();
  }
  fetchMainInfoId(){
    this.personalInfoService.getMainInfoId().subscribe((data)=>{
      this.infoId=data
      this.fetchData(this.infoId)
    })
  }
  fetchData(id: string){
    this.experienceService.getExperienceByInfoId(id).subscribe((data)=>{
      this.experiences =data;
    })
  }
}
