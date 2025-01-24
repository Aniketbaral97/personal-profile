import { Component, OnInit } from '@angular/core';
import { SidebarComponent } from "../sidebar/sidebar.component";
import { AdminGetManySkillDto, AdminSkill, CreateSkill } from '../../../models/admin/personal_profile_request';
import { SkillLevel, SkillTypes } from '../../../models/enums/enums';
import { SkillService } from '../../../services/skill_service';
import { ToastrService } from 'ngx-toastr';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { PersonalInfoService } from '../../../services/personalInfo_service';

@Component({
  selector: 'app-skill',
  imports: [SidebarComponent, CommonModule, FormsModule],
  templateUrl: './skill.component.html',
  styleUrl: './skill.component.scss'
})
export class SkillComponent implements OnInit {
  getSkillsModel: AdminGetManySkillDto={skills:[]}
  skillTypeOptions: {key:string, value:number}[]=[];
  skillLevelOptions:{key:string, value:number}[]=[];
  skillTypes: typeof SkillTypes =SkillTypes
  skillLevels:typeof SkillLevel =SkillLevel
  infoId: string="00000000-0000-0000-0000-000000000000"
  constructor(private skillService: SkillService, private toast:ToastrService, private personalInfoService: PersonalInfoService){}

  ngOnInit(): void {
    this.skillLevelOptions = Object.keys(this.skillLevels).filter((key) => isNaN(Number(key))).map(
          (key) => ({
            key,
            value: this.skillLevels[key as keyof typeof SkillLevel],
          })
        )
        this.skillTypeOptions = Object.keys(this.skillTypes).filter((key) => isNaN(Number(key))).map(
          (key) => ({
            key,
            value: this.skillTypes[key as keyof typeof SkillTypes],
          })
        )
        this.fetchMainInfoId();
      }
      fetchMainInfoId(){
        this.personalInfoService.getMainInfoId().subscribe((data)=>{
          this.infoId=data
          this.fetcSkill(this.infoId)
        })
      }
    fetcSkill(id:string){
        this.skillService.getSkillByInfoId(id).subscribe((data)=>{
          this.getSkillsModel =data;
        })
      }
    addSkill() {
        let newItem: AdminSkill = {
          id: '00000000-0000-0000-0000-000000000000',
          type:0,
          level:0,
        }
        this.getSkillsModel.skills.push(newItem);
      }
      saveSkill() {
        let id = "6f9619ff-8b86-d011-b42d-00cf4fc964ff";
        let mappedResult: AdminSkill[] = this.getSkillsModel.skills.filter(x => x.id == '00000000-0000-0000-0000-000000000000');
        let createRequest: CreateSkill = {
          skills: mappedResult,
          personalInfoId: id
        }
        this.skillService.createSkill(createRequest).subscribe((data) => {
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
      updatePersanalInfo(updateRequest: AdminSkill) {
        this.skillService.updateSkill(updateRequest).subscribe((data) => {
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
          this.getSkillsModel.skills.splice(index, 1);
          return;
        }
        this.skillService.deleteSkill(id).subscribe((data) => {
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
      onLevelChange(type: string, index: number) {
        this.getSkillsModel.skills[index].level = type ? Number(type) : 1
      }
      onTypeChange(type: string, index: number) {
        this.getSkillsModel.skills[index].type = type ? Number(type) : 1
      }
      
}
