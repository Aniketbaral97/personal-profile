import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { GetManySkillDto } from "../models/ui/personal_infos";
@Injectable({
    providedIn:'root'
}) 
export class SkillService {
    private apiUrl = "http://localhost:5005/api/skill/";
    constructor(private http: HttpClient){}

    getSkillByInfoId(id:string): Observable<GetManySkillDto>{
        return this.http.get<GetManySkillDto>(this.apiUrl +id);
    }
}