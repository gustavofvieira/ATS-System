import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { CandidateComponent } from './candidate/candidate.component';
import { JobVacancyComponent } from './job-vacancy/job-vacancy.component';
import { JobApplicationComponent } from './job-application/job-application.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'candidate', component: CandidateComponent },
  { path: 'jobVacancy', component: JobVacancyComponent },
  { path: 'jobApplication', component: JobApplicationComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
