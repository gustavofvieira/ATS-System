import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Candidate } from 'src/app/components/candidate/candidate';

const httpOptions ={
  headers: new HttpHeaders({
    'Content-Type' : 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class CandidateService {
  url = 'https://localhost:7149/api/candidate';
  constructor(private http: HttpClient) { }

  GetAll(): Observable<Candidate[]>{
    return this.http.get<Candidate[]>(`${this.url}/GetAll`);
  }

  GetById(candidateId: string): Observable<Candidate>{
    const apiUrl = `${this.url}/GetById?id=${candidateId}`;
    return this.http.get<Candidate>(apiUrl);
  }

  CreateCandidate(candidate: Candidate) : Observable<any>{
    const apiUrl = `${this.url}/Create`;
    return this.http.post<Candidate>(apiUrl, candidate, httpOptions)
  }

  UpdateCandidate(candidate: Candidate) : Observable<any>{
    const apiUrl = `${this.url}/Update`;
    return this.http.put<Candidate>(apiUrl, candidate, httpOptions)
  }

  DeleteCandidate(candidateId: string) : Observable<any>{
    const apiUrl = `${this.url}/Delete?id=${candidateId}`;
    return this.http.delete<string>(apiUrl, httpOptions)
  }
}
