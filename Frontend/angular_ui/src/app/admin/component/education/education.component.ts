import { Component, OnInit } from '@angular/core';
import { SidebarComponent } from '../sidebar/sidebar.component';
import { GradingTypes } from '../../../models/enums/enums';
import { EducationService } from '../../../services/education_services';
import { ToastrService } from 'ngx-toastr';
import { AdminEducation, AdminGetEducations, CreateEducations } from '../../../models/admin/personal_profile_request';
import { Education } from '../../../models/ui/personal_infos';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { PersonalInfoService } from '../../../services/personalInfo_service';

@Component({
  selector: 'app-education',
  imports: [SidebarComponent, CommonModule, FormsModule],
  templateUrl: './education.component.html',
  styleUrl: './education.component.scss'
})
export class EducationComponent implements OnInit {
  getEducationModel: AdminGetEducations = { educations: [] }
  gradingOptions: { key: string, value: number }[] = [];
  gradings: typeof GradingTypes = GradingTypes;
  infoId: string="00000000-0000-0000-0000-000000000000"
  constructor(private educationService: EducationService, private toast: ToastrService, private personalInfoService: PersonalInfoService) { }
  ngOnInit(): void {
    this.gradingOptions = Object.keys(this.gradings).filter((key) => isNaN(Number(key))).map(
      (key) => ({
        key,
        value: this.gradings[key as keyof typeof GradingTypes],
      })
    )
    console.log(this.gradingOptions)
    this.fetchMainInfoId();
  }
  fetchMainInfoId(){
    this.personalInfoService.getMainInfoId().subscribe((data)=>{
      this.infoId=data
      this.fetchEducations(this.infoId)
    })
  }
  fetchEducations(id:string) {
    this.educationService.getEducationById(id).subscribe((data) => {
      this.getEducationModel = data
    })
  }
  onGradingChange(type: string, index: number) {
    this.getEducationModel.educations[index].gradingType = type ? Number(type) : 1
  }
  addEducation() {
    let newItem: AdminEducation = {
      id: '00000000-0000-0000-0000-000000000000',
      gradingType: 0,
      grading: 0,
      isCurrent: false

    }
    this.getEducationModel.educations.push(newItem);
  }
  saveEducation() {
    let id = "6f9619ff-8b86-d011-b42d-00cf4fc964ff";
    let mappedResult: AdminEducation[] = this.getEducationModel.educations.filter(x => x.id == '00000000-0000-0000-0000-000000000000');
    let createRequest: CreateEducations = {
      educations: mappedResult,
      personalInfoId: id
    }
    this.educationService.createEducations(createRequest).subscribe((data) => {
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
  updatePersanalInfo(updateRequest: AdminEducation) {
    this.educationService.updateEducation(updateRequest).subscribe((data) => {
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
      this.getEducationModel.educations.splice(index, 1);
      return;
    }
    this.educationService.deleteEducation(id).subscribe((data) => {
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
