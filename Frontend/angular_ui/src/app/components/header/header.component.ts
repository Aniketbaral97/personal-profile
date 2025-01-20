import { ChangeDetectorRef, Component, Input } from '@angular/core';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  imports:[RouterLink],
  styleUrls: ['./header.component.scss', '../../app.component.scss']
})
export class HeaderComponent {
  
}
