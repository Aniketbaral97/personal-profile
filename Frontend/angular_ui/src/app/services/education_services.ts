import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs/internal/Observable";
import { GetEducations } from "../models/ui/personal_infos";
import { AdminEducation, AdminGetEducations, CreateEducations } from "../models/admin/personal_profile_request";
import { ApiResultModel } from "../models/admin/loginRequestModel";
import { ErrorService } from "./error_service";
import { catchError, tap } from "rxjs";

@Injectable({
    providedIn: 'root'
})
export class EducationService {
    private apiUrl = 'http://localhost:5005/api/education/'
    constructor(private http: HttpClient, private erroService: ErrorService) { }

    getEducationById(id: string): Observable<GetEducations> {
        return this.http.get<GetEducations>(this.apiUrl + id);
    }

    createEducations(request: CreateEducations):Observable<ApiResultModel<number>>{
        try{
            return this.http.post<ApiResultModel<number>>(this.apiUrl, request).pipe(
                tap(()=>{}),    
                catchError((e)=>{
                   return this.erroService.catchErrorHandler(e)
                })
            )
        }
        catch(e)
        {
            return this.erroService.catchErrorHandler(e);
        }
    }
    updateEducation(request: AdminEducation):Observable<ApiResultModel<number>>{
        try{
            return this.http.put<ApiResultModel<number>>(this.apiUrl+request.id, request).pipe(
                tap(()=>{}),    
                catchError((e)=>{
                   return this.erroService.catchErrorHandler(e)
                })
            )
        }
        catch(e)
        {
            return this.erroService.catchErrorHandler(e);
        }
    }
    deleteEducation(id: string):Observable<ApiResultModel<number>>{
        try{
            return this.http.delete<ApiResultModel<number>>(this.apiUrl+id).pipe(
                tap(()=>{}),    
                catchError((e)=>{
                   return this.erroService.catchErrorHandler(e)
                })
            )
        }
        catch(e)
        {
            return this.erroService.catchErrorHandler(e);
        }
    }
}