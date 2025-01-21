import { Observable, of } from "rxjs";
import { ApiResultModel } from "../models/admin/loginRequestModel";
import { Injectable } from "@angular/core";
@Injectable({
    providedIn:'root'
})
export class ErrorService {
    getError(error: any, statusCode: number): ApiResultModel<string> {
        return {
            success: false,
            httpStatusCode: statusCode,
            response: null,
            errors: error.error || ["An unexpected error occurred."]
        };
    }
    extractErrorMessage(error: any): string {
        if (error.error?.message) {
            return error.error.message;
        } else if (error.status === 0) {
            return "Unable to connect to the server. Please try again later.";
        } else {
            return "An unexpected error occurred. Please try again.";
        }
    }

    catchErrorHandler(error: any) : Observable<ApiResultModel<any>>{
        var errorMessage =this.extractErrorMessage(error);
        let errorResult: ApiResultModel<string> = this.getError(errorMessage, 500);
        return of(errorResult);
    }
}