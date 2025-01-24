import { ChangeDetectorRef, Component, Input, OnInit, SimpleChanges } from '@angular/core';
import { GetEducations } from '../../../models/ui/personal_infos';
import { EducationService } from '../../../services/education_services';
import { CommonModule } from '@angular/common';
import { EnumService } from '../../../services/enum_service';
import { PersonalInfoService } from '../../../services/personalInfo_service';

@Component({
  selector: 'app-education',
  imports: [CommonModule],
  templateUrl: './education.component.html',
  styleUrls: ['./education.component.scss', '../../../app.component.scss']
})
export class EducationComponent implements OnInit {
  @Input() isActive: boolean = false;
  educations: GetEducations = { educations: [] };
  infoId: string="00000000-0000-0000-0000-000000000000"
  constructor(private educationService: EducationService, private enumService:EnumService, private cdRef: ChangeDetectorRef, private personalInfoService: PersonalInfoService) { }
  ngOnInit(): void {
    this.fetchMainInfoId();
  }
  fetchMainInfoId(){
    this.personalInfoService.getMainInfoId().subscribe((data)=>{
      this.infoId=data
      this.fetchData(this.infoId)
    })
  }
  ngOnChanges(changes: SimpleChanges) :void {
    if (changes['isActive'] && this.isActive) {
      this.fetchData(this.infoId);
      this.cdRef.detectChanges();
    }
  }
  public fetchData(id:string) {
    this.educationService.getEducationById(id).subscribe((data)=>{
      this.educations = data
    })
  }
  getGradingTypesEnumKey(gender:number){
    return this.enumService.getGradingTypesEnumKey(gender)
  }
}
