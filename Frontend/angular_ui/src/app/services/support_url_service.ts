import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { GetSupportUrls } from "../models/ui/personal_infos";
@Injectable({
    providedIn:'root'
})
export class SupportUrlService
{
    private apiUrl = 'http://localhost:5005/api/support-url/'
    constructor(private http: HttpClient){}

    getSupportUrlByInfoId(id:string):Observable<GetSupportUrls>{
        return this.http.get<GetSupportUrls>(this.apiUrl+id)
    }
}