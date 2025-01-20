import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { LoginRequestModel } from '../models/admin/loginRequestModel';
import { AuthService } from '../services/auth_service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-login',
  imports: [FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {
  loginRequest: LoginRequestModel= {username:'',password:''};
  constructor(private loginService:AuthService, private toastr: ToastrService){}
  
  login()
  {
    this.loginService.signIn(this.loginRequest.username,this.loginRequest.password).subscribe((data)=>
    {
      console.log(data.errors);
      if(data.errors.length > 0)
      {
        for (let index = 0; index < data.errors.length; index++) {
          const element = data.errors[index];
          console.log("Item:"+element);
          this.toastr.error(element,"Auth Error")
        }
        return;
      }
      this.toastr.success("Login Successful","Auth Complete")
    });
  }
}
