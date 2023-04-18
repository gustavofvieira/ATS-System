import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { CandidateComponent } from './components/candidate/candidate.component';
import { JobVacancyComponent } from './components/job-vacancy/job-vacancy.component';
import { LoginComponent } from './components/user/login/login.component';
import { UpdatePasswordComponent } from './components/user/updatePassword/update-password.component';
import { RecoverPassComponent } from './components/user/recoverPassword/recover-pass.component';
import { CreateUserComponent } from './components/user/create/create.component';

const routes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'home', component: HomeComponent },
  { path: 'updatePassword', component: UpdatePasswordComponent },
  { path: 'recoverPassword', component: RecoverPassComponent },
  { path: 'createUser', component: CreateUserComponent },
  { path: 'candidate', component: CandidateComponent },
  { path: 'jobVacancy', component: JobVacancyComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
