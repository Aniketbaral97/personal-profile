import { Component, OnInit } from '@angular/core';
import { AdminPersonalInfoDemoList, AdminPersonalInfoDemoRequest } from '../../../models/admin/personal_profile_request';
import { PersonalInfoService } from '../../../services/personalInfo_service';
import { ToastrService } from 'ngx-toastr';
import { ErrorService } from '../../../services/error_service';
import { catchError, tap, throwError } from 'rxjs';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { WorkAvailabilityStatus } from '../../../models/enums/enums';
import { SidebarComponent } from '../sidebar/sidebar.component';

@Component({
  selector: 'app-profiles',
  imports: [FormsModule, CommonModule, SidebarComponent],
  templateUrl: './profiles.component.html',
  styleUrl: './profiles.component.scss'
})
export class ProfilesComponent implements OnInit {
  profiles: AdminPersonalInfoDemoList = { personalInfos: [], totalPages: 0 }
  request: AdminPersonalInfoDemoRequest = { workAvailabilityStatus: 0, offset: 0 }
  workStatus: typeof WorkAvailabilityStatus =WorkAvailabilityStatus;
  constructor(private personalInfoService: PersonalInfoService, private toast: ToastrService, private errorService: ErrorService) { }

  ngOnInit(): void {
    this.fetchData();
  }
  fetchData() {
    try {
      this.personalInfoService.getPersonalInfo(this.request).pipe(
        tap(() => { }),
        catchError((e) => {
          const errorMessage = this.errorService.extractErrorMessage(e);
          this.toast.error(errorMessage);
          return throwError(e);
        })
      ).subscribe((data) => {
        this.profiles = data
      })
    }
    catch (e) {
    }
  }

}
