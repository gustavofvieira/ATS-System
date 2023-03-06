import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { JobVacancy } from 'src/app/components/job-vacancy/job-vacancy';

const httpOptions ={
  headers: new HttpHeaders({
    'Content-Type' : 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class JobVacancyService {
  url = 'https://localhost:7149/api/JobVacancy';
  constructor(private http: HttpClient) { }

  GetAll(): Observable<JobVacancy[]>{
    return this.http.get<JobVacancy[]>(`${this.url}/GetAll`);
  }

  GetById(jobVacancyId: string): Observable<JobVacancy>{
    const apiUrl = `${this.url}/GetById?id=${jobVacancyId}`;
    return this.http.get<JobVacancy>(apiUrl);
  }

  CreateJobVacancy(jobVacancy: JobVacancy) : Observable<any>{
    const apiUrl = `${this.url}/Create`;
    return this.http.post<JobVacancy>(apiUrl, jobVacancy, httpOptions)
  }

  UpdateJobVacancy(jobVacancy: JobVacancy) : Observable<any>{
    const apiUrl = `${this.url}/Update`;
    return this.http.put<JobVacancy>(apiUrl, jobVacancy, httpOptions)
  }

  CreateJobApplication(jobVacancyId: any, candidateId: any) : Observable<any>{
    const apiUrl = `${this.url}/JobApplication?jobVacancyId=${jobVacancyId}&candidateId=${candidateId}`;
    return this.http.put<JobVacancy>(apiUrl, httpOptions)
  }

  DeleteJobVacancy(jobVacancyId: string) : Observable<any>{
    const apiUrl = `${this.url}/Delete?id=${jobVacancyId}`;
    return this.http.delete<string>(apiUrl, httpOptions)
  }
}
