import { Component, OnInit } from '@angular/core';
import { GetEducations } from '../../../models/ui/personal_infos';
import { EducationService } from '../../../services/education_services';
import { CommonModule } from '@angular/common';
import { EnumService } from '../../../services/enum_service';

@Component({
  selector: 'app-education',
  imports: [CommonModule],
  templateUrl: './education.component.html',
  styleUrl: './education.component.scss'
})
export class EducationComponent implements OnInit {
  educations: GetEducations = { educations: [] };
  constructor(private educationService: EducationService, private enumService:EnumService) { }
  ngOnInit(): void {
    this.fetchData();
  }

  public fetchData() {
    this.educationService.getEducationById("6f9619ff-8b86-d011-b42d-00cf4fc964ff").subscribe((data)=>{
      this.educations = data
    })
  }
  getGradingTypesEnumKey(gender:number){
    return this.enumService.getGradingTypesEnumKey(gender)
  }
}
