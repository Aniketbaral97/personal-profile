import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { GetSupportUrls } from '../../../models/ui/personal_infos';
import { SupportUrlService } from '../../../services/support_url_service';
import { EnumService } from '../../../services/enum_service';

@Component({
  selector: 'app-support-url',
  imports: [CommonModule],
  templateUrl: './support-url.component.html',
  styleUrls: ['./support-url.component.scss', '../../../app.component.scss']
})
export class SupportUrlComponent implements OnInit {
  supportUrls: GetSupportUrls={supportUrls:[]}
  constructor(private supportUrlService: SupportUrlService, private enumService: EnumService){}

  ngOnInit(): void {
    this.fetchData();
  }
  fetchData(){
    this.supportUrlService.getSupportUrlByInfoId('6f9619ff-8b86-d011-b42d-00cf4fc964ff').subscribe((data)=>{
      this.supportUrls =data
    })
  }
  getUrlTypesEnumKey(gender:number){
    return this.enumService.getUrlTypesEnumKey(gender)
  }
}
