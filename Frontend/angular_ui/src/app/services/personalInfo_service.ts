import { HttpClient } from "@angular/common/http";
import { catchError, Observable, tap } from "rxjs";
import { PersonalInfo } from "../models/ui/personal_infos";
import { Injectable } from "@angular/core";
import { AdminPersonalInfo, AdminPersonalInfoDemoList, AdminPersonalInfoDemoRequest } from "../models/admin/personal_profile_request";
import { ApiResultModel } from "../models/admin/loginRequestModel";
import { ErrorService } from "./error_service";

@Injectable({
    providedIn: 'root', // Automatically registers the service globally
})
export class PersonalInfoService {
    private apiUrl = 'http://localhost:5005/api/personal-info';
    constructor(private http: HttpClient, private errorService: ErrorService) { }

    getPersonalInfoById(id: string): Observable<PersonalInfo> {
        return this.http.get<PersonalInfo>(this.apiUrl +"/"+ id);
    }
    getPersonalInfo(request:AdminPersonalInfoDemoRequest): Observable<AdminPersonalInfoDemoList> {
        
        var url='?offset='+request.offset;
        if(request.name != null)
        {
            url +="name="+request.name
        }
        if(request.workAvailabilityStatus > 0)
        {
            url += "status="+request.workAvailabilityStatus
        }
        return this.http.get<AdminPersonalInfoDemoList>(this.apiUrl + url);
    }

    createPersonalInfo(request: AdminPersonalInfo): Observable<ApiResultModel<string>> {
        try {
            return this.http.post<ApiResultModel<string>>(this.apiUrl, request).pipe(
                tap(() => {

                }),
                catchError((error) => {
                    return this.errorService.catchErrorHandler(error);
                })
            );
        }
        catch (e) {
            return this.errorService.catchErrorHandler(e)
        }
    }

    updatePersonalInfo(request: AdminPersonalInfo): Observable<ApiResultModel<number>>{
        try{
            return this.http.put<ApiResultModel<number>>(this.apiUrl +"/"+ request.id, request)
            .pipe(tap(),catchError((error)=>{
                return this.errorService.catchErrorHandler(error);
            }))
        }
        catch(e){
            return this.errorService.catchErrorHandler(e);
        }
    }

    deletePersonalInfo(id:string): Observable<ApiResultModel<number>>{
        try{
            return this.http.delete<ApiResultModel<number>>(this.apiUrl+"/"+id).pipe(
                tap(),
                catchError((e)=>{
                    return this.errorService.catchErrorHandler(e)
                })
            )
        }
        catch(e)
        {
            return this.errorService.catchErrorHandler(e);
        }
    }
}