import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { catchError, Observable, tap } from "rxjs";
import { GetManySkillDto } from "../models/ui/personal_infos";
import { AdminSkill, CreateSkill } from "../models/admin/personal_profile_request";
import { ApiResultModel } from "../models/admin/loginRequestModel";
import { ErrorService } from "./error_service";
@Injectable({
    providedIn:'root'
}) 
export class SkillService {
    private apiUrl = "http://localhost:5005/api/skill/";
    constructor(private http: HttpClient, private errorService:ErrorService){}

    getSkillByInfoId(id:string): Observable<GetManySkillDto>{
        return this.http.get<GetManySkillDto>(this.apiUrl +id);
    }
    createSkill(request: CreateSkill):Observable<ApiResultModel<number>>{
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
        updateSkill(request: AdminSkill):Observable<ApiResultModel<number>>{
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
        deleteSkill(id:string):Observable<ApiResultModel<number>>{
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