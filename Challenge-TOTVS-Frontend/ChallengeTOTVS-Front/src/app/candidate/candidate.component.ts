import { Component, OnInit, TemplateRef, Inject, LOCALE_ID  } from '@angular/core';
import {FormGroup, FormControl} from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Candidate } from './candidate';
import { CandidateService } from './candidate.service';
import {  formatDate } from '@angular/common';

@Component({
  selector: 'app-candidate',
  templateUrl: './candidate.component.html',
  styleUrls: ['./candidate.component.css']
})

export class CandidateComponent implements OnInit{

  constructor(@Inject(LOCALE_ID) public locale: string,private candidateService: CandidateService,
  private modalService: BsModalService) {}

  FormatDateStr(dateStr :any): string{
    return formatDate(dateStr, 'dd/MM/yyyy' ,this.locale);
}

  form: any;
  titleForm: string | undefined;
  candidates: Candidate[] | undefined;
  nameCandidate: string | undefined;
  candidateId: string | undefined;
  createdAt: string | undefined;

  visibleTable: boolean = true;
  visibleForm: boolean = false; 
  
  modalRef: BsModalRef | any;

  

  ngOnInit(): void {
    this.candidateService.GetAll().subscribe((result) => {
      console.log(result)
      this.candidates = result;
    });
  }

  ShowFormRegister(): void {
    this.visibleTable = false;
    this.visibleForm = true;
    this.titleForm = 'New candidate';
    this.form = new FormGroup({
      name: new FormControl(null),
      birthday: new FormControl(null),
      login: new FormControl(null),
      password: new FormControl(null),
    });
  }

  ShowFormUpdate(candidateId :any): void {
    this.visibleTable = false;
    this.visibleForm = true;
    console.log("entoru no metodo");
    this.candidateService.GetById(candidateId).subscribe((result) => {
      this.titleForm = `Update ${result.name} ${result.login}`;
      console.log("entoru no getById: ", result.login);
      this.form = new FormGroup({
        candidateId: new FormControl(result.candidateId),
        birthday: new FormControl(result.birthday),
        name: new FormControl(result.name),
        createdAt: new FormControl(result.createdAt),
        login: new FormControl(result.login),
        password: new FormControl(result.password),
      });
    });
  }

  SendForm(): void {
    const candidate: Candidate = this.form.value;

    if (candidate.candidateId != null) {
      console.log("entrou no update");
      this.candidateService.UpdateCandidate(candidate).subscribe((resultado) => {
        this.visibleForm = false;
        this.visibleTable = true;
        alert('Pessoa atualizada com sucesso');
        this.candidateService.GetAll().subscribe((registros) => {
          this.candidates = registros;
        });
      });
    } else {
      console.log("entrou no create");
      this.candidateService.CreateCandidate(candidate).subscribe((resultado) => {
        this.visibleForm = false;
        this.visibleTable = true;
        alert('Candidate created with success');
        this.candidateService.GetAll().subscribe((registros) => {
          this.candidates = registros;
        });
      });
    }
  }

  Back(): void {
    this.visibleTable = true;
    this.visibleForm = false;
  }

  ShowConfirmDelete(candidateId: any, nameCandidate: any, contentModal: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(contentModal);
    this.candidateId = candidateId;
    this.nameCandidate = nameCandidate;
  }

  DeleteCandidate(candidateId: any){
    this.candidateService.DeleteCandidate(candidateId).subscribe(resultado => {
      this.modalRef.hide();
      alert('Candidate deleted with success');
      this.candidateService.GetAll().subscribe(registros => {
        this.candidates = registros;
      });
    });
  }
}

