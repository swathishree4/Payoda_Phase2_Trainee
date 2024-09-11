import { bootstrapApplication } from '@angular/platform-browser';
import { appConfig } from './app/app.config';
import { AppComponent } from './app/app.component';
import { SamBindingComponent } from './app/sam-binding/sam-binding.component';
import { SportsComponent } from './app/sports/sports.component';

bootstrapApplication(AppComponent, appConfig)
  .catch((err) => console.error(err));
