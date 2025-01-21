import { HttpClient } from "@angular/common/http";
import { catchError, Observable, tap } from "rxjs";
import { GetExperiences } from "../models/ui/personal_infos";
import { Injectable } from "@angular/core";
import { AdminExperience, CreateExperience } from "../models/admin/personal_profile_request";
import { ApiResultModel } from "../models/admin/loginRequestModel";
import { ErrorService } from "./error_service";
@Injectable({
    providedIn :'root'
})
export class ExperienceService{
    private apiUrl = "http://localhost:5005/api/experience/"; 
    constructor(private http : HttpClient,private errorService:ErrorService){}
    getExperienceByInfoId(id:string) : Observable<GetExperiences>{
        return this.http.get<GetExperiences>(this.apiUrl+id)
    }

    createExperience(request: CreateExperience):Observable<ApiResultModel<number>>{
        try{
            return this.http.post<ApiResultModel<number>>(this.apiUrl, request).pipe(
                tap(()=>{}),
                catchError((e)=>{
                    return this.errorService.catchErrorHandler(e);
                })
            )
        }
        catch(e)
        {
            return this.errorService.catchErrorHandler(e);
        }
    }
    updateExperience(request: AdminExperience):Observable<ApiResultModel<number>>{
        try{
            return this.http.put<ApiResultModel<number>>(this.apiUrl+request.id, request).pipe(
                tap(()=>{}),
                catchError((e)=>{
                    return this.errorService.catchErrorHandler(e);
                })
            )
        }
        catch(e)
        {
            return this.errorService.catchErrorHandler(e);
        }
    }
    deleteExperience(id:string):Observable<ApiResultModel<number>>{
        try{
            return this.http.delete<ApiResultModel<number>>(this.apiUrl+id).pipe(
                tap(()=>{}),
                catchError((e)=>{
                    return this.errorService.catchErrorHandler(e);
                })
            )
        }
        catch(e)
        {
            return this.errorService.catchErrorHandler(e);
        }
    }
}