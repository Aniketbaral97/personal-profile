import { ChangeDetectorRef, Component, Input, OnInit, SimpleChanges } from '@angular/core';
import { GetEducations } from '../../../models/ui/personal_infos';
import { EducationService } from '../../../services/education_services';
import { CommonModule } from '@angular/common';
import { EnumService } from '../../../services/enum_service';

@Component({
  selector: 'app-education',
  imports: [CommonModule],
  templateUrl: './education.component.html',
  styleUrls: ['./education.component.scss', '../../../app.component.scss']
})
export class EducationComponent implements OnInit {
  @Input() isActive: boolean = false;
  educations: GetEducations = { educations: [] };
  constructor(private educationService: EducationService, private enumService:EnumService, private cdRef: ChangeDetectorRef) { }
  ngOnInit(): void {
    console.log("========================");
    this.fetchData();
  }
  ngOnChanges(changes: SimpleChanges) :void {
    console.log("*************************");
    console.log('Active:'+this.isActive)
    if (changes['isActive'] && this.isActive) {
      this.fetchData();
      this.cdRef.detectChanges();
    }
  }
  public fetchData() {
    this.educationService.getEducationById("6f9619ff-8b86-d011-b42d-00cf4fc964ff").subscribe((data)=>{
      console.log(data); 
      this.educations = data
    })
  }
  getGradingTypesEnumKey(gender:number){
    return this.enumService.getGradingTypesEnumKey(gender)
  }
}
