import { HttpClient } from '@angular/common/http';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Observable } from 'rxjs';
import { Subscription } from 'rxjs';
import { Question } from 'src/app/_models/question';
import { QuestionnaireService } from 'src/app/services/questionnaire.service';

@Component({
  selector: 'app-questionnaire',
  templateUrl: './questionnaire.component.html',
  styleUrls: ['./questionnaire.component.scss']
})
export class QuestionnaireComponent implements OnInit{
  constructor(private questionnaire: QuestionnaireService, private http: HttpClient) { }

  QuestionsList: Question[];


  ngOnInit(): void {
    throw new Error('Method not implemented.');
  }

  getDiseases() {
    this.questionnaire.getQuestionnaire().subscribe(response => {
      this.QuestionsList = response;
    }, error => {
      console.log(error);
    })
  }

}
