import { Component, OnInit } from '@angular/core';
import { SidebarComponent } from "../sidebar/sidebar.component";
import { SupportUrlService } from '../../../services/support_url_service';
import { ToastrService } from 'ngx-toastr';
import { UrlTypes } from '../../../models/enums/enums';
import { AdminGetSupportUrls, AdminSupportUrl, CreateSupportUrl } from '../../../models/admin/personal_profile_request';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { PersonalInfoService } from '../../../services/personalInfo_service';

@Component({
  selector: 'app-support-url',
  imports: [SidebarComponent, CommonModule, FormsModule],
  templateUrl: './support-url.component.html',
  styleUrl: './support-url.component.scss'
})
export class SupportUrlComponent implements OnInit {
  getSupportUrlModel: AdminGetSupportUrls = { supportUrls: [] }
  urlTypeOptions: { key: string, value: number }[] = [];
  urlTypes: typeof UrlTypes = UrlTypes
  infoId: string="00000000-0000-0000-0000-000000000000"
  constructor(private supportUrlService: SupportUrlService, private toast: ToastrService, private personalInfoService: PersonalInfoService) { }

  ngOnInit(): void {
    this.urlTypeOptions = Object.keys(this.urlTypes).filter((key) => isNaN(Number(key))).map(
      (key) => ({
        key,
        value: this.urlTypes[key as keyof typeof UrlTypes],
      })
    )
    this.fetchMainInfoId();
  }
  fetcSkill(id:string) {
    this.supportUrlService.getSupportUrlByInfoId(id).subscribe((data) => {
      this.getSupportUrlModel = data;
    })
  }
  fetchMainInfoId(){
    this.personalInfoService.getMainInfoId().subscribe((data)=>{
      this.infoId=data
      this.fetcSkill(this.infoId)
    })
  }
  addSkill() {
    let newItem: AdminSupportUrl = {
      id: '00000000-0000-0000-0000-000000000000',
      type: 0,
    }
    this.getSupportUrlModel.supportUrls.push(newItem);
  }
  saveSkill() {
    let id = "6f9619ff-8b86-d011-b42d-00cf4fc964ff";
    let mappedResult: AdminSupportUrl[] = this.getSupportUrlModel.supportUrls.filter(x => x.id == '00000000-0000-0000-0000-000000000000');
    let createRequest: CreateSupportUrl = {
      supportUrls: mappedResult,
      personalInfoId: id
    }
    this.supportUrlService.createSupportUrl(createRequest).subscribe((data) => {
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
  updatePersanalInfo(updateRequest: AdminSupportUrl) {
    this.supportUrlService.updateSupportUrl(updateRequest).subscribe((data) => {
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
      this.getSupportUrlModel.supportUrls.splice(index, 1);
      return;
    }
    this.supportUrlService.deleteSupportUrl(id).subscribe((data) => {
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
  onTypeChange(type: string, index: number) {
    this.getSupportUrlModel.supportUrls[index].type = type ? Number(type) : 1
  }
}
