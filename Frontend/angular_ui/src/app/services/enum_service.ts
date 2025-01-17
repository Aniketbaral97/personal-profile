import { Injectable } from "@angular/core";
import { ActiveStatus, Gender, GradingTypes, SkillLevel, SkillTypes, UrlTypes, UserGroup } from "../models/enums/enums";
@Injectable({
    providedIn:'root'
})
export class EnumService{
    getSkillLevelEnumKey(value: number): string {
        return SkillLevel[value];
      }
    getGenderEnumKey(value: number): string {
        return Gender[value];
    }
    getSkillTypesEnumKey(value: number): string {
        return SkillTypes[value];
    }
    getUserGroupEnumKey(value: number): string {
        return UserGroup[value];
    }
    getUrlTypesEnumKey(value: number): string {
        return UrlTypes[value];
    }
    getGradingTypesEnumKey(value: number): string {
        return GradingTypes[value];
    }
    getActiveStatusEnumKey(value: number): string {
        return ActiveStatus[value];
    }
    
}