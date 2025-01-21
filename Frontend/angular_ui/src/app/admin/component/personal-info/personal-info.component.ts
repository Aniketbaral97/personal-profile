import { Component, OnInit } from '@angular/core';
import { SidebarComponent } from "../sidebar/sidebar.component";
import { Gender } from '../../../models/enums/enums';
import { CommonModule } from '@angular/common';
import { AdminPersonalInfo } from '../../../models/admin/personal_profile_request';
import { PersonalInfoService } from '../../../services/personalInfo_service';
import { ToastrService } from 'ngx-toastr';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-personal-info',
  imports: [SidebarComponent, CommonModule, FormsModule],
  templateUrl: './personal-info.component.html',
  styleUrl: './personal-info.component.scss'
})
export class PersonalInfoComponent implements OnInit {
  genderOptions: { key: string; value: number }[] = [];
  genderStatus: typeof Gender = Gender;
  id:string='6f9619ff-8b86-d011-b42d-00cf4fc964ff';
  request: AdminPersonalInfo={
    id:'00000000-0000-0000-0000-000000000000',  
    gender:0  
  }
  constructor(private service: PersonalInfoService, private toast: ToastrService){}
  ngOnInit(): void {
    this.genderOptions = Object.keys(this.genderStatus)
      .filter((key) => isNaN(Number(key))) // Filter out numeric keys
      .map((key) => ({
        key,
        value: this.genderStatus[key as keyof typeof Gender],
      }));
      console.log(this.genderOptions);
    this.request.id=this.id;
    this.fetchPersonalInfo();
  }

  fetchPersonalInfo(){
    this.service.getPersonalInfoById(this.id).subscribe((data)=>{
      this.request = data
    })
  }

  savePersonalInfo()
  {
    this.service.createPersonalInfo(this.request).subscribe((data)=>{
      if(data.errors.length > 0)
      {
        for (let index = 0; index < data.errors.length; index++) {
          const element = data.errors[index];
          this.toast.error(element, data.httpStatusCode.toString());
        }
        return;
      }
      this.toast.success('Personal info added succesfully', "Success("+data.httpStatusCode.toString()+")");
    })
  }
  updatePersanalInfo()
  {
    console.log(this.request);
    this.service.updatePersonalInfo(this.request).subscribe((data)=>{
      if(data.errors.length > 0)
      {
        for (let index = 0; index < data.errors.length; index++) {
          const element = data.errors[index];
          this.toast.error(element, data.httpStatusCode.toString());
        }
        return;
      }
      this.toast.success('Personal info update succesfully', "Success("+data.httpStatusCode.toString()+")");
    })
  }
  deletePersanalInfo()
  {
    this.service.deletePersonalInfo(this.id).subscribe((data)=>{
      if(data.errors.length > 0)
      {
        for (let index = 0; index < data.errors.length; index++) {
          const element = data.errors[index];
          this.toast.error(element, data.httpStatusCode.toString());
        }
        return;
      }
      this.toast.success('Personal info deleted succesfully', "Success("+data.httpStatusCode.toString()+")");
    })
  }
  onGenderChange(value: string): void {
    this.request.gender = value ? Number(value) : 0;
  }
}
