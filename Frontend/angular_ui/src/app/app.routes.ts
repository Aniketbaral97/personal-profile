import { Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { AuthGuard } from './services/auth_guard_service';
import { AdminComponent } from './admin/admin.component';
import { PersonalInfoComponent } from './admin/component/personal-info/personal-info.component';
import { EducationComponent } from './admin/component/education/education.component';
import { ExperienceComponent } from './admin/component/experience/experience.component';
import { SkillComponent } from './admin/component/skill/skill.component';
import { SupportUrlComponent } from './admin/component/support-url/support-url.component';

export const routes: Routes = [
    { path:'login', component: LoginComponent},
    { path: '', component: HomeComponent},
    { path:'dashboard', component:AdminComponent,canActivate: [AuthGuard] },
    { path:'personal-info', component:PersonalInfoComponent,canActivate: [AuthGuard] },
    { path:'education', component:EducationComponent,canActivate: [AuthGuard] },
    { path:'experience', component:ExperienceComponent,canActivate: [AuthGuard] },
    { path:'skill', component:SkillComponent,canActivate: [AuthGuard] },
    { path:'support-url', component:SupportUrlComponent,canActivate: [AuthGuard] }
];
