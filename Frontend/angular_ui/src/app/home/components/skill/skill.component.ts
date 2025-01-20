import { Component, OnInit } from '@angular/core';
import { GetManySkillDto } from '../../../models/ui/personal_infos';
import { SkillService } from '../../../services/skill_service';
import { CommonModule } from '@angular/common';
import { SkillLevel } from '../../../models/enums/enums';
import { EnumService } from '../../../services/enum_service';
import { animate, style, transition, trigger } from '@angular/animations';

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

  constructor(private skillService: SkillService, private enumService: EnumService) {}

  ngOnInit(): void {
    this.fetchData();
  }

  fetchData() {
    this.skillService.getSkillByInfoId('6f9619ff-8b86-d011-b42d-00cf4fc964ff').subscribe((data) => {
      this.skills = data;
      console.log(data);
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
