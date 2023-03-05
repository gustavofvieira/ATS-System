import { Candidate } from "../candidate/candidate";

export class JobApplication {
    jobVacancyId: string | undefined;
    title: string | undefined;
    candidates: Candidate[] | undefined; 
}