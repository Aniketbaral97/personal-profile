import { HttpClient } from "@angular/common/http";
import { ErrorService } from "./error_service";
import { catchError, Observable, tap } from "rxjs";
import { GetReferences } from "../models/ui/personal_infos";
import { AdminReference, CreateReferences } from "../models/admin/personal_profile_request";
import { ApiResultModel } from "../models/admin/loginRequestModel";
import { Injectable } from "@angular/core";

@Injectable({
    providedIn:'root'
})
export class ReferenceService {
    private apiUrl = "http://localhost:5005/api/reference/"
    constructor(private http: HttpClient, private errorService: ErrorService) { }

    getReferenceByInfoId(id: string): Observable<GetReferences> {
        return this.http.get<GetReferences>(this.apiUrl + id);
    }

    createReferences(request: CreateReferences): Observable<ApiResultModel<Number>> {
        try {
            return this.http.post<ApiResultModel<Number>>(this.apiUrl, request).pipe(
                tap(() => { }),
                catchError((e) => {
                    return this.errorService.catchErrorHandler(e);
                })
            )
        }
        catch (e) {
            return this.errorService.catchErrorHandler(e)
        }
    }
    updateReference(request: AdminReference): Observable<ApiResultModel<number>> {
        try {
            return this.http.put<ApiResultModel<number>>(this.apiUrl + request.id, request).pipe(
                tap(() => { }),
                catchError((e) => {
                    return this.errorService.catchErrorHandler(e);
                })
            )
        }
        catch (e) {
            return this.errorService.catchErrorHandler(e);
        }
    }
    deleteReference(id: string): Observable<ApiResultModel<number>> {
        try {
            return this.http.delete<ApiResultModel<number>>(this.apiUrl + id).pipe(
                tap(() => { }),
                catchError((e) => {
                    return this.errorService.catchErrorHandler(e);
                })
            )
        }
        catch (e) {
            return this.errorService.catchErrorHandler(e);
        }
    }
}