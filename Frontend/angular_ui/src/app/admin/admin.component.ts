import { Component } from '@angular/core';
import { SidebarComponent } from "./component/sidebar/sidebar.component";

@Component({
  selector: 'app-admin',
  imports: [SidebarComponent],
  templateUrl: './admin.component.html',
  styleUrl: './admin.component.scss'
})
export class AdminComponent {

}
