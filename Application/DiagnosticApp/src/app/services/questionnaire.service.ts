import { HttpClient, HttpHeaders,HttpRequest,HttpEvent } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Question } from '../_models/question';

@Injectable({
  providedIn: 'root'
})
export class QuestionnaireService {

  constructor(private http: HttpClient) { }

  readonly BaseURL= environment.BaseURL;

  readonly getAllQuestions = this.BaseURL + "Questionnaire/GetAll";

  getQuestionnaire() {
    return this.http.get<Question[]>(this.getAllQuestions);
  }

}
