import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { HeaderComponent } from './components/header/header.component';

@Component({
  selector: 'app-root',
  imports: [HomeComponent, HeaderComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  currentSection: string = 'About'; // Default section is 'about'

  updateSection(section: string): void {
    this.currentSection = section;  // Update the section to show in Personal Data component
  }
}
