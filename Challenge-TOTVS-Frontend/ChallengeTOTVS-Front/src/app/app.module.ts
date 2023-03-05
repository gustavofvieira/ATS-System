import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CandidateComponent } from './candidate/candidate.component';
import { HomeComponent } from './home/home.component';
import { JobVacancyComponent } from './job-vacancy/job-vacancy.component';

import { CandidateService } from './candidate/candidate.service';
import { JobVacancyService } from './job-vacancy/job-vacancy.service';

import { CommonModule } from '@angular/common';
import { HttpClientModule } from "@angular/common/http";
import { ReactiveFormsModule } from "@angular/forms";

import { ModalModule } from "ngx-bootstrap/modal";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { JobApplicationComponent } from './job-application/job-application.component';


@NgModule({
  declarations: [
    AppComponent,
    CandidateComponent,
    HomeComponent,
    JobVacancyComponent,
    JobApplicationComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    CommonModule,
    HttpClientModule,
    ReactiveFormsModule,
    ModalModule.forRoot()
  ],
  providers: [HttpClientModule,CandidateService, JobVacancyService],
  bootstrap: [AppComponent]
})
export class AppModule { }
