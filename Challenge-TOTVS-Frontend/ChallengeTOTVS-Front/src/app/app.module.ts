import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CandidateComponent } from './candidate/candidate.component';
import { JobApplicationComponent } from './job-application/job-application.component';
import { HomeComponent } from './home/home.component';
import { JobVacancyComponent } from './job-vacancy/job-vacancy.component';

@NgModule({
  declarations: [
    AppComponent,
    CandidateComponent,
    JobApplicationComponent,
    HomeComponent,
    JobVacancyComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
