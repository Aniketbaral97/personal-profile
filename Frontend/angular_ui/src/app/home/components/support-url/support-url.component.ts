import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { GetSupportUrls } from '../../../models/ui/personal_infos';
import { SupportUrlService } from '../../../services/support_url_service';
import { EnumService } from '../../../services/enum_service';
import { PersonalInfoService } from '../../../services/personalInfo_service';

@Component({
  selector: 'app-support-url',
  imports: [CommonModule],
  templateUrl: './support-url.component.html',
  styleUrls: ['./support-url.component.scss', '../../../app.component.scss']
})
export class SupportUrlComponent implements OnInit {
  infoId: string="00000000-0000-0000-0000-000000000000"
  supportUrls: GetSupportUrls={supportUrls:[]}
  constructor(private supportUrlService: SupportUrlService, private enumService: EnumService, private personalInfoService: PersonalInfoService){}

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
    this.supportUrlService.getSupportUrlByInfoId(id).subscribe((data)=>{
      this.supportUrls =data
    })
  }
  getUrlTypesEnumKey(gender:number){
    return this.enumService.getUrlTypesEnumKey(gender)
  }
}
