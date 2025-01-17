import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs/internal/Observable";
import { GetEducations } from "../models/ui/personal_infos";

@Injectable({
    providedIn: 'root'
})
export class EducationService {
    private apiUrl = 'http://localhost:5005/api/education/'
    constructor(private http: HttpClient) { }

    getEducationById(id: string): Observable<GetEducations> {
        return this.http.get<GetEducations>(this.apiUrl + id);
    }
}