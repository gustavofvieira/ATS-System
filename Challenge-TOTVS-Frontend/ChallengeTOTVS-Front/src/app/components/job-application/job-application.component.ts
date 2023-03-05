import { Component, OnInit, TemplateRef, Inject, LOCALE_ID } from '@angular/core';
import {FormGroup, FormControl} from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { JobVacancy } from '../job-vacancy/job-vacancy';
import { JobVacancyService } from '../job-vacancy/job-vacancy.service';
import {  formatDate } from '@angular/common';

@Component({
  selector: 'app-job-application',
  templateUrl: './job-application.component.html',
  styleUrls: ['./job-application.component.css']
})

export class JobApplicationComponent implements OnInit{

  
  FormatDateStr(dateStr :any): string{
    return formatDate(dateStr, 'dd/MM/yyyy' ,this.locale);
}

  constructor(@Inject(LOCALE_ID) public locale: string,private jobVacancyService: JobVacancyService,
    private modalService: BsModalService) {}

   
  form: any;
  titleForm: string | undefined;
  jobVacancies: JobVacancy[] | undefined;
  title: string | undefined;
  jobVacancyId: string | undefined;
    candidateId: string | undefined;

  visibleTable: boolean = true;
  visibleForm: boolean = false; 
  
  modalRef: BsModalRef | any;

  ngOnInit(): void {
    this.jobVacancyService.GetAll().subscribe((result) => {
      console.log(result)
      this.jobVacancies = result;
    });
  }
 

  ShowFormRegister(): void {
    this.visibleTable = false;
    this.visibleForm = true;
    this.titleForm = 'New Job Application';
    this.form = new FormGroup({
      jobVacancyId: new FormControl(null),
      candidateId: new FormControl(null),
    });
  }

  ShowFormUpdate(jobVacancyId :any): void {
    this.visibleTable = false;
    this.visibleForm = true;
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

  
      this.jobVacancyService.CreateJobApplication(jobVacancy.jobVacancyId,jobVacancy.candidateId).subscribe((result) => {
        this.visibleForm = false;
        this.visibleTable = true;
        alert('Job application created with success');
        this.jobVacancyService.GetAll().subscribe((registers) => {
          this.jobVacancies = registers;
        });
      });
    
  }

  Back(): void {
    this.visibleTable = true;
    this.visibleForm = false;
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

