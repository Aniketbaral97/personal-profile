import { HttpEvent, HttpHandler, HttpInterceptor, HttpInterceptorFn, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

// @Injectable({
//   providedIn: 'root'
// })
// export class CustomeInterceptor implements HttpInterceptor {
//   constructor() { }
//   intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
//     if (typeof window === 'undefined') {
//       return next.handle(req);
//     }
//     console.log("======================")
//     var token = localStorage.getItem('jwt_token');
//     console.log("===Token===" + token)
//     if (token) {
//       const clonedRequest = req.clone({
//         setHeaders: {
//           Authorization: `Bearer ${token}`,
//         },
//       });
//       return next.handle(clonedRequest);
//     }
//     return next.handle(req);
//   }
// }

export const customInterceptor: HttpInterceptorFn = (req, next) => {
  if (typeof window === 'undefined') {
    return next(req);
  }

  const token = localStorage.getItem('jwt_token');
  if (token) {
    const clonedRequest = req.clone({
      setHeaders: { Authorization: `Bearer ${token}` },
    });
    return next(clonedRequest);
  }

  return next(req);
};