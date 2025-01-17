import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { GetExperiences } from "../models/ui/personal_infos";
import { Injectable } from "@angular/core";
@Injectable({
    providedIn :'root'
})
export class ExperienceService{
    private apiUrl = "http://localhost:5005/api/experience/"; 
    constructor(private http : HttpClient){}
    getExperienceByInfoId(id:string) : Observable<GetExperiences>{
        return this.http.get<GetExperiences>(this.apiUrl+id)
    }
}