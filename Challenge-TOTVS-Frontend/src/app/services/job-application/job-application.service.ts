import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Candidate } from 'src/app/components/candidate/candidate';
import { HttpClient, HttpHeaders } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class JobApplicationService {

  url = 'https://localhost:7149/api/JobApplication';
  constructor(private http: HttpClient) { }

  
  GetCandidatesByJobId(jobVacancyId: string): Observable<Candidate[]>{
    const apiUrl = `${this.url}/GetCandidatesByJobId?jobId=${jobVacancyId}`;
    return this.http.get<Candidate[]>(apiUrl);
  }
}
