import { Component } from '@angular/core';
import { SidebarComponent } from '../sidebar/sidebar.component';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { AdminGetReferences, AdminReference, CreateReferences } from '../../../models/admin/personal_profile_request';
import { ReferenceService } from '../../../services/reference_service';
import { ToastrService } from 'ngx-toastr';
import { PersonalInfoService } from '../../../services/personalInfo_service';

@Component({
  selector: 'app-reference',
  imports: [SidebarComponent, FormsModule, CommonModule],
  templateUrl: './reference.component.html',
  styleUrl: './reference.component.scss'
})
export class ReferenceComponent {
  getReferencesModel: AdminGetReferences = { references: [] }
  infoId: string="00000000-0000-0000-0000-000000000000"
  constructor(private referenceService: ReferenceService, private toast: ToastrService, private personalInfoService: PersonalInfoService) { }

  ngOnInit(): void {
    this.fetchMainInfoId();
  }
  fetcReference(id:string) {
    this.referenceService.getReferenceByInfoId(id).subscribe((data) => {
      this.getReferencesModel = data;
    })
  }
  fetchMainInfoId(){
    this.personalInfoService.getMainInfoId().subscribe((data)=>{
      this.infoId=data
      this.fetcReference(this.infoId)
    })
  }
  addReference() {
    let newItem: AdminReference = {
      id: '00000000-0000-0000-0000-000000000000',
      name: '',
      position: '',
      workPlace: ''
    }
    this.getReferencesModel.references.push(newItem);
  }
  saveReference() {
    let id = "6f9619ff-8b86-d011-b42d-00cf4fc964ff";
    let mappedResult: AdminReference[] = this.getReferencesModel.references.filter(x => x.id == '00000000-0000-0000-0000-000000000000');
    let createRequest: CreateReferences = {
      references: mappedResult,
      personalInfoId: id
    }
    this.referenceService.createReferences(createRequest).subscribe((data) => {
      if (data.errors.length > 0) {
        for (let index = 0; index < data.errors.length; index++) {
          const element = data.errors[index];
          this.toast.error(element, data.httpStatusCode.toString());
        }
        return;
      }
      this.toast.success('Reference added succesfully', "Success(" + data.httpStatusCode.toString() + ")");
    })
  }
  updatePersanalInfo(updateRequest: AdminReference) {
    this.referenceService.updateReference(updateRequest).subscribe((data) => {
      if (data.errors.length > 0) {
        for (let index = 0; index < data.errors.length; index++) {
          const element = data.errors[index];
          this.toast.error(element, data.httpStatusCode.toString());
        }
        return;
      }
      this.toast.success('Reference update succesfully', "Success(" + data.httpStatusCode.toString() + ")");
    })
  }
  deletePersanalInfo(id: string, index: number) {
    if (id == '00000000-0000-0000-0000-000000000000') {
      this.getReferencesModel.references.splice(index, 1);
      return;
    }
    this.referenceService.deleteReference(id).subscribe((data) => {
      if (data.errors.length > 0) {
        for (let index = 0; index < data.errors.length; index++) {
          const element = data.errors[index];
          this.toast.error(element, data.httpStatusCode.toString());
        }
        return;
      }
      this.toast.success('Reference deleted succesfully', "Success(" + data.httpStatusCode.toString() + ")");
    })
  }
}
