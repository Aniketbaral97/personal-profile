import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { catchError, Observable, tap } from "rxjs";
import { GetSupportUrls } from "../models/ui/personal_infos";
import { ApiResultModel } from "../models/admin/loginRequestModel";
import { AdminSupportUrl, CreateSupportUrl } from "../models/admin/personal_profile_request";
import { ErrorService } from "./error_service";
@Injectable({
    providedIn:'root'
})
export class SupportUrlService
{
    private apiUrl = 'http://localhost:5005/api/support-url/'
    constructor(private http: HttpClient, private errorService: ErrorService){}

    getSupportUrlByInfoId(id:string):Observable<GetSupportUrls>{
        return this.http.get<GetSupportUrls>(this.apiUrl+id)
    }
    createSupportUrl(request: CreateSupportUrl):Observable<ApiResultModel<number>>{
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
        updateSupportUrl(request: AdminSupportUrl):Observable<ApiResultModel<number>>{
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
        deleteSupportUrl(id:string):Observable<ApiResultModel<number>>{
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