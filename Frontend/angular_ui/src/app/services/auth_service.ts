import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { ApiResultModel } from "../models/admin/loginRequestModel";
import { catchError, Observable, of, tap } from "rxjs";
import { Router } from "@angular/router";

@Injectable({
    providedIn: 'root'
})
export class AuthService {
    private apiUrl = "http://localhost:5005/api/auth/login";
    constructor(private http: HttpClient, private route: Router) { }


    signIn(username: string, password: string): Observable<ApiResultModel<string>> {
      try{
        return this.http.post<ApiResultModel<string>>(this.apiUrl, {
              username: username,
              password: password
          }).pipe(
              tap((data) => {
                localStorage.setItem("jwt_token", data.response!);
                this.route.navigateByUrl('dashboard');
              }),
              catchError((error) => {
                var errorMessage =this.extractErrorMessage(error);
                let errorResult: ApiResultModel<string> = this.getError(errorMessage, 503);
                return of(errorResult);
              })
          );
      }
      catch(e)
      {
        var errorMessage =this.extractErrorMessage(e);
                let errorResult: ApiResultModel<string> = this.getError(errorMessage, 500);
                return of(errorResult);
      }
    }

  private getError(error: any, statusCode:number): ApiResultModel<string> {
    return {
      success: false,
      httpStatusCode: 501,
      response: null,
      errors: error.error || ["An unexpected error occurred."]
    };
  }
  private extractErrorMessage(error: any): string {
    if (error.error?.message) {
      return error.error.message;
    } else if (error.status === 0) {
      return "Unable to connect to the server. Please try again later.";
    } else {
      return "An unexpected error occurred. Please try again.";
    }
  }
}


