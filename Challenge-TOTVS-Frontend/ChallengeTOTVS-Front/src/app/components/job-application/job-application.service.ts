import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { JobApplication } from './job-application';

@Injectable({
  providedIn: 'root'
})
export class JobApplicationService {
  url = 'https://localhost:7149/api/JobApplication';
  constructor(private http: HttpClient) { }

  GetAll(): Observable<JobApplication[]>{
    return this.http.get<JobApplication[]>(`${this.url}/GetAll`);
  }

}
