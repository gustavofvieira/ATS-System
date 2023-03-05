import { Component, OnInit, TemplateRef, Inject, LOCALE_ID } from '@angular/core';
import {FormGroup, FormControl} from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { JobApplicationService } from '../job-application/job-application.service';
import {  formatDate } from '@angular/common';
import { Candidate } from '../candidate/candidate';
import { JobApplication } from './job-application';

@Component({
  selector: 'app-job-application',
  templateUrl: './job-application.component.html',
  styleUrls: ['./job-application.component.css']
})

export class JobApplicationComponent implements OnInit{

  
  FormatDateStr(dateStr :any): string{
    return formatDate(dateStr, 'dd/MM/yyyy' ,this.locale);
}

  constructor(@Inject(LOCALE_ID) public locale: string,private jobApplicationService: JobApplicationService,
    private modalService: BsModalService) {}

   
  form: any;
  titleForm: string | undefined;
  jobApplications: JobApplication[] | undefined;
  candidates: Candidate[] | undefined;
  title: string | undefined;
  jobVacancyId: string | undefined;
  candidateId: string | undefined;

  visibleTable: boolean = true;
  visibleForm: boolean = false; 
  
  modalRef: BsModalRef | any;

  ngOnInit(): void {
    this.jobApplicationService.GetAll().subscribe((result) => {
      console.log("jobApp",result)
      this.jobApplications = result;
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

  // ShowFormUpdate(jobVacancyId :any): void {
  //   this.visibleTable = false;
  //   this.visibleForm = true;
  //   this.jobApplicationService.GetById(jobVacancyId).subscribe((result) => {
  //     this.titleForm = `Update ${result.title} ${result.createdAt}`;
  //     this.form = new FormGroup({
  //       jobVacancyId: new FormControl(result.jobVacancyId),
  //       title: new FormControl(result.title),
  //       description: new FormControl(result.description),
  //       startDate: new FormControl(result.startDate),
  //       expirateDate: new FormControl(result.expirateDate),
  //       candidateIds: new FormControl(result.candidateIds),
  //     });
  //   });
  // }

  // SendForm(): void {
  //   const jobVacancy: JobVacancy = this.form.value;

  
  //     this.jobApplicationService.CreateJobApplication(jobVacancy.jobVacancyId,jobVacancy.candidateId).subscribe((result) => {
  //       this.visibleForm = false;
  //       this.visibleTable = true;
  //       alert('Job application created with success');
  //       this.jobApplicationService.GetAll().subscribe((registers) => {
  //         this.jobApplication = registers;
  //       });
  //     });
    
  // }

  Back(): void {
    this.visibleTable = true;
    this.visibleForm = false;
  }
}

