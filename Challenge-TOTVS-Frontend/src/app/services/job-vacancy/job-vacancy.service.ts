import { HttpClient, HttpHeaders,HttpErrorResponse  } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { JobVacancy } from 'src/app/components/job-vacancy/job-vacancy';
import { catchError } from 'rxjs/operators';
import { LocalStorageService } from '../local-storage.service';

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
  constructor(private http: HttpClient,private localStorageService: LocalStorageService) { }

  GetAll2(): Observable<JobVacancy[]>{
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

  CreateJobVacancyAuth(jobVacancy: JobVacancy) : Observable<any>{
    const httpOptionsAuth ={
      headers: new HttpHeaders({
        'Content-Type' : 'application/json',
        'Authorization' : 'Bearer '+this.localStorageService.get("token")
      })
    }
    const apiUrl = `${this.url}/Create`;
    return this.http.post<JobVacancy>(apiUrl, jobVacancy, httpOptionsAuth).pipe(
      catchError((error: HttpErrorResponse) => this.handleError(error, "Error to Authenticate!"))
    ); 
  }

  GetAll() : Observable<JobVacancy[]>{
    const httpOptionsAuth ={
      headers: new HttpHeaders({
        'Content-Type' : 'application/json',
        'Authorization' : 'Bearer '+this.localStorageService.get("token")
      })
    }
    const apiUrl = `${this.url}/GetAll`;
    return this.http.get<JobVacancy[]>(apiUrl,  httpOptionsAuth).pipe(
      catchError((error: HttpErrorResponse) => this.handleError(error, "Error to Authenticate!"))
    ); 
  }


  Authenticated() : Observable<any>{
    const httpOptionsAuth ={
      headers: new HttpHeaders({
        'Content-Type' : 'application/json',
        'Authorization' : 'Bearer '+this.localStorageService.get("token")
      })
    }
    const apiUrl = `${this.url}/authenticated`;
    return this.http.get<any>(apiUrl, httpOptionsAuth).pipe(
      catchError((error: HttpErrorResponse) => this.handleError(error, "Error to Authenticate!"))
    ); 
  }

  DeleteJobVacancy(jobVacancyId: string) : Observable<any>{
    const apiUrl = `${this.url}/Delete?id=${jobVacancyId}`;
    return this.http.delete<string>(apiUrl, httpOptions)
  }

  private handleError(error: HttpErrorResponse, customErrorMessage: string) {
    if (error.error instanceof ErrorEvent) {
      console.error('Ocorreu um erro:', error.error.message);
    } else {
      console.error(
        `Código do erro ${error.status}, ` +
        `erro: ${JSON.stringify(error.error)}`);
    }
    return throwError(customErrorMessage);
  }
}
