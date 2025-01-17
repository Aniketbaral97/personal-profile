import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { PersonalInfo } from "../models/ui/personal_infos";
import { Injectable } from "@angular/core";

@Injectable({
    providedIn: 'root', // Automatically registers the service globally
  })
export class PersonalInfoService{
    private apiUrl = 'http://localhost:5005/api/personal-info/';
    constructor(private http: HttpClient) { }

    getPersonalInfoById(id: string):Observable<PersonalInfo> {
        return this.http.get<PersonalInfo>(this.apiUrl + id);
    }
}