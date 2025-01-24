import { Component, OnInit } from '@angular/core';
import { GetReferences } from '../../../models/ui/personal_infos';
import { ReferenceService } from '../../../services/reference_service';
import { CommonModule } from '@angular/common';
import { PersonalInfoService } from '../../../services/personalInfo_service';

@Component({
  selector: 'app-reference',
  imports: [CommonModule],
  templateUrl: './reference.component.html',
  styleUrls: ['./reference.component.scss', '../../../app.component.scss']
})
export class ReferenceComponent implements OnInit {
 references?: GetReferences
 infoId: string="00000000-0000-0000-0000-000000000000"
 constructor(private referenceService:ReferenceService , private personalInfoService: PersonalInfoService){}

 ngOnInit(): void {
  this.fetchMainInfoId();
 }
 fetchMainInfoId(){
  this.personalInfoService.getMainInfoId().subscribe((data)=>{
    this.infoId=data
    this.fetchData(this.infoId)
  })
}
 fetchData(id:string){
  this.referenceService.getReferenceByInfoId(id).subscribe((data)=>{
    this.references=data;
  })
 }
}
