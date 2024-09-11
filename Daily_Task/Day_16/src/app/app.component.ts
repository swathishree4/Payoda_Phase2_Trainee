import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { SamBindingComponent } from './sam-binding/sam-binding.component';
import { SportsComponent } from './sports/sports.component';
@Component({
  selector: 'app-root',
  standalone: true,
  imports: [SamBindingComponent,SportsComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'This is angular';
}
