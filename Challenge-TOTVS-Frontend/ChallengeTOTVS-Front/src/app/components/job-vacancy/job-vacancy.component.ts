import { Component, OnInit, TemplateRef, Inject, LOCALE_ID } from '@angular/core';
import {FormGroup, FormControl} from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { JobVacancy } from './job-vacancy';
import { JobVacancyService } from 'src/app/services/job-vacancy/job-vacancy.service';
import { JobApplicationService } from 'src/app/services/job-application/job-application.service';
import {  formatDate } from '@angular/common';
import { Candidate } from '../candidate/candidate';

@Component({
  selector: 'app-job-vacancy',
  templateUrl: './job-vacancy.component.html',
  styleUrls: ['./job-vacancy.component.css']
})

export class JobVacancyComponent implements OnInit{

  
  FormatDateStr(dateStr :any): string{
    return formatDate(dateStr, 'dd/MM/yyyy' ,this.locale);
}

FormatDateTimeStr(dateStr :any): string{
  return formatDate(dateStr, 'dd/MM/yyyy HH:mm:ss' ,this.locale);
}

  constructor(@Inject(LOCALE_ID) public locale: string,private jobVacancyService: JobVacancyService,private jobApplicationService: JobApplicationService,
    private modalService: BsModalService) {}

   
  form: any;
  titleForm: string | undefined;
  jobVacancies: JobVacancy[] | undefined;
  title: string | undefined;
  jobVacancyId: string | undefined;
    description: string | undefined;
    startDate: Date | undefined;
    expirateDate: Date | undefined;
    candidateIds: string[] | undefined;
    candidates: Candidate[] | undefined;
  visibleTable: boolean = true;
  visibleForm: boolean = false; 
  visibleCandidates: boolean =false;
  
  modalRef: BsModalRef | any;

  ngOnInit(): void {
    this.jobVacancyService.GetAll().subscribe((result) => {
      this.jobVacancies = result;
    });
  }
 
  ShowCandidates(jobVacancyId :any): void {
    this.visibleTable = false;
     this.visibleCandidates = true;
    //  this.titleForm = `Update ${result.title} ${result.createdAt}`;
     this.jobApplicationService.GetCandidatesByJobId(jobVacancyId).subscribe((result) => {
       this.candidates = result;
       console.log("candidates",this.candidates);
     });
    
    }

  ShowFormRegister(): void {
    this.visibleTable = false;
    this.visibleForm = true;
    this.visibleCandidates = false;
    this.titleForm = 'New Job Vacancy';
    this.form = new FormGroup({
      title: new FormControl(null),
      description: new FormControl(null),
      startDate: new FormControl(null),
      expirateDate: new FormControl(null),
      candidateIds: new FormControl([]),
    });
  }

  ShowFormUpdate(jobVacancyId :any): void {
    this.visibleTable = false;
    this.visibleForm = true;
    this.visibleCandidates = false;
    this.jobVacancyService.GetById(jobVacancyId).subscribe((result) => {
      this.titleForm = `Update ${result.title} ${result.createdAt}`;
      this.form = new FormGroup({
        jobVacancyId: new FormControl(result.jobVacancyId),
        title: new FormControl(result.title),
        description: new FormControl(result.description),
        startDate: new FormControl(result.startDate),
        expirateDate: new FormControl(result.expirateDate),
        candidateIds: new FormControl(result.candidateIds),
      });
    });
  }

  SendForm(): void {
    const jobVacancy: JobVacancy = this.form.value;

    if (jobVacancy.jobVacancyId != null) {
      console.log("entrou no update");
      this.jobVacancyService.UpdateJobVacancy(jobVacancy).subscribe((result) => {
        this.visibleForm = false;
        this.visibleTable = true;
        alert('Pessoa atualizada com sucesso');
        this.jobVacancyService.GetAll().subscribe((registers) => {
          this.jobVacancies = registers;
        });
      });
    } else {
      this.jobVacancyService.CreateJobVacancy(jobVacancy).subscribe((result) => {
        this.visibleForm = false;
        this.visibleTable = true;
        alert('Job Vacancy created with success');
        this.jobVacancyService.GetAll().subscribe((registers) => {
          this.jobVacancies = registers;
        });
      });
    }
  }

  Back(): void {
    this.visibleTable = true;
    this.visibleForm = false;
    this.visibleCandidates = false;
  }

  ShowConfirmDelete(jobVacancyId: any, titleVacancy: any, contentModal: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(contentModal);
    this.jobVacancyId = jobVacancyId;
    this.title = titleVacancy;
  }

  DeleteJobVacancy(jobVacancyId: any){
    this.jobVacancyService.DeleteJobVacancy(jobVacancyId).subscribe(resultado => {
      this.modalRef.hide();
      alert('Job Vacancy deleted with success');
      this.jobVacancyService.GetAll().subscribe(registros => {
        this.jobVacancies = registros;
      });
    });
  }
}

