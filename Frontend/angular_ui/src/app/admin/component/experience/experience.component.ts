import { Component, OnInit } from '@angular/core';
import { SidebarComponent } from "../sidebar/sidebar.component";
import {  AdminExperience, AdminGetExperiences, CreateExperience } from '../../../models/admin/personal_profile_request';
import { ExperienceService } from '../../../services/experience_service';
import { ToastrService } from 'ngx-toastr';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-experience',
  imports: [SidebarComponent, CommonModule, FormsModule],
  templateUrl: './experience.component.html',
  styleUrl: './experience.component.scss'
})
export class ExperienceComponent implements OnInit {
  getExperienceModel: AdminGetExperiences={experiences:[]}
  constructor(private experienceService:ExperienceService, private toast:ToastrService){}
  ngOnInit(): void {
    this.fetcExperience();
  }
  fetcExperience(){
    let id='6f9619ff-8b86-d011-b42d-00cf4fc964ff'
    this.experienceService.getExperienceByInfoId(id).subscribe((data)=>{
      this.getExperienceModel =data;
    })
  }
addExperience() {
    let newItem: AdminExperience = {
      id: '00000000-0000-0000-0000-000000000000',
      isCurrent:false
    }
    this.getExperienceModel.experiences.push(newItem);
  }
  saveExperience() {
    let id = "6f9619ff-8b86-d011-b42d-00cf4fc964ff";
    let mappedResult: AdminExperience[] = this.getExperienceModel.experiences.filter(x => x.id == '00000000-0000-0000-0000-000000000000');
    let createRequest: CreateExperience = {
      experiences: mappedResult,
      personalInfoId: id
    }
    this.experienceService.createExperience(createRequest).subscribe((data) => {
      if (data.errors.length > 0) {
        for (let index = 0; index < data.errors.length; index++) {
          const element = data.errors[index];
          this.toast.error(element, data.httpStatusCode.toString());
        }
        return;
      }
      this.toast.success('Personal info added succesfully', "Success(" + data.httpStatusCode.toString() + ")");
    })
  }
  updatePersanalInfo(updateRequest: AdminExperience) {
    this.experienceService.updateExperience(updateRequest).subscribe((data) => {
      if (data.errors.length > 0) {
        for (let index = 0; index < data.errors.length; index++) {
          const element = data.errors[index];
          this.toast.error(element, data.httpStatusCode.toString());
        }
        return;
      }
      this.toast.success('Personal info update succesfully', "Success(" + data.httpStatusCode.toString() + ")");
    })
  }
  deletePersanalInfo(id: string, index: number) {
    if (id == '00000000-0000-0000-0000-000000000000') {
      this.getExperienceModel.experiences.splice(index, 1);
      return;
    }
    this.experienceService.deleteExperience(id).subscribe((data) => {
      if (data.errors.length > 0) {
        for (let index = 0; index < data.errors.length; index++) {
          const element = data.errors[index];
          this.toast.error(element, data.httpStatusCode.toString());
        }
        return;
      }
      this.toast.success('Personal info deleted succesfully', "Success(" + data.httpStatusCode.toString() + ")");
    })
  }
  
}
