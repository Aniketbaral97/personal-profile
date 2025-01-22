import { Component, OnInit } from '@angular/core';
import { GetReferences } from '../../../models/ui/personal_infos';
import { ReferenceService } from '../../../services/reference_service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-reference',
  imports: [CommonModule],
  templateUrl: './reference.component.html',
  styleUrls: ['./reference.component.scss', '../../../app.component.scss']
})
export class ReferenceComponent implements OnInit {
 references?: GetReferences
 constructor(private referenceService:ReferenceService){}

 ngOnInit(): void {
  this.fetchData();
 }
 fetchData(){
  this.referenceService.getReferenceByInfoId('6f9619ff-8b86-d011-b42d-00cf4fc964ff').subscribe((data)=>{
    this.references=data;
  })
 }
}
