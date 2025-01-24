import { Component, OnInit } from '@angular/core';
import { GetManySkillDto, Skill } from '../../../models/ui/personal_infos';
import { SkillService } from '../../../services/skill_service';
import { CommonModule } from '@angular/common';
import { SkillLevel, SkillTypes } from '../../../models/enums/enums';
import { EnumService } from '../../../services/enum_service';
import { animate, style, transition, trigger } from '@angular/animations';
import { PersonalInfoService } from '../../../services/personalInfo_service';

@Component({
  selector: 'app-skill',
  imports: [CommonModule],
  templateUrl: './skill.component.html',
  styleUrls: ['./skill.component.scss', '../../../app.component.scss'],
  animations: [
    trigger('progressAnimation', [
      transition(':enter', [
        style({ width: '0%' }), // Initial width
        animate('1s ease-out')
      ])
    ])
  ]
})
export class SkillComponent implements OnInit {
  skills: GetManySkillDto = { skills: [] };
  Level: SkillLevel = SkillLevel.Beginner;
  infoId: string="00000000-0000-0000-0000-000000000000"
  groupedSkills: { [key: string]: Skill[] } = {};
  Object = Object; 
  constructor(private skillService: SkillService, private enumService: EnumService, private personalInfoService: PersonalInfoService) {}

  ngOnInit(): void {
    this.fetchMainInfoId();
  }
  fetchMainInfoId(){
    this.personalInfoService.getMainInfoId().subscribe((data)=>{
      this.infoId=data
      this.fetchData(this.infoId)
    })
  }
  groupSkillsByType(): void {
    this.groupedSkills = this.skills.skills.reduce((groups, skill) => {
      const typeText = SkillTypes[skill.type] || 'Other';
      if(!groups[typeText])
      {
        groups[typeText]=[]
      }
      groups[typeText].push(skill)
      return groups;
    }, {} as { [key: string]: Skill[] });
  }
  fetchData(id:string) {
    this.skillService.getSkillByInfoId(id).subscribe((data) => {
      this.skills = data;
      this.groupSkillsByType();
    });
  }

  getSkillTypesEnumKey(gender: number) {
    return this.enumService.getSkillTypesEnumKey(gender);
  }

  getSkillLevelEnumKey(gender: number) {
    return this.enumService.getSkillLevelEnumKey(gender);
  }

  getSkillLevelPercentage(level: number): number {
    switch (level) {
      case 1:
        return 20;
      case 2:
        return 40;
      case 3:
        return 60;
      case 4:
        return 80;
      case 5:
        return 100;
      default:
        return 0;
    }
  }
}
