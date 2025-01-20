export interface LoginRequestModel{
    username: string;
    password : string;
}

export interface ApiResultModel<T>{
    response:T | null,
    success:boolean,
    errors:string[] | [],
    httpStatusCode:number
}