import { HttpClient } from '@angular/common/http';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Observable } from 'rxjs';
import { Subscription } from 'rxjs';
import { Question } from 'src/app/_models/question';
import { QuestionnaireService } from 'src/app/services/questionnaire.service';
import { Router } from '@angular/router';
import { FormGroup, FormBuilder, Validators, FormArray, FormControl } from '@angular/forms';
import { Symptom } from 'src/app/_models/symptom';
import { DiseasesService } from 'src/app/services/diseases.service';

@Component({
  selector: 'app-questionnaire',
  templateUrl: './questionnaire.component.html',
  styleUrls: ['./questionnaire.component.scss']
})
export class QuestionnaireComponent implements OnInit{
  constructor(private fb: FormBuilder, private questionnaire: QuestionnaireService, private disease: DiseasesService, private http: HttpClient, private router: Router) {
    this.quizForm = this.fb.group({
      'answers': ['']
    });
    this.form = this.fb.group({
      selectedSymptoms:  new FormArray([])
     });
    this.form3 = this.fb.group({
      otherSymptoms:  new FormArray([])
     });
   }

  quizForm: FormGroup;
  form: FormGroup;
  form3: FormGroup;

  preliminarySymptoms: Array<any> = [
    { name: 'Wysoka glukoza - powyżej 99 mg/dL', value: '30,156' },
    { name: 'Niska hemoglobina - poniżej 12 g/dl dla kobiet i poniżej 13 g/dl dla mężczyzn', value: '67' },
    { name: 'Niski hematokryt - poniżej 37% dla kobiet i poniżej 40% dla mężczyzn', value: '68' },
    { name: 'Niskie erytrocyty - poniżej 3,5 mln/mm3 dla kobiet i poniżej 4,2 mln/mm3 dla mężczyzn', value: '69' },
    { name: 'Wysokie TSH - powyżej 5 mU/I', value: '106' },
    { name: 'Niskie FT3 - poniżej 2,25 pmol/I', value: '107' },
    { name: 'Niskie FT4 - poniżej 10 pmol/I', value: '108' },
    { name: 'Niskie TSH - poniżej 0,32 mU/I', value: '120' },
    { name: 'Wysokie FT3 - powyżej 6 pmol/I', value: '121' },
    { name: 'Wysokie FT4 - powyżej 35 pmol/I', value: '122' },
    { name: 'Wysoki cholesterol - powyżej 200 mg/dL', value: '226' },
    { name: 'Niskie płytki krwi - poniżej 150 tys.', value: '154' },
    { name: 'Wysokie ALT - powyżej 40 Iu/I, AST - powyżej 40 IU/I, ALP - powyżej 120 IU/I', value: '155' },
    { name: 'Podwyższone ciśnienie spoczynkowe - powyżej 130/90 mmHg', value: '177' },
    { name: 'Niskie ciśnienie spoczynkowe - poniżej 100/60 mmHg', value: '184' },
    { name: 'Wysokie CRP - powyżej 5 mg/l', value: '193' },
    { name: 'Wysoki poziom leukocytów - powyżej 10 tys.', value: '194' },
    { name: 'Wysokie OB - powyżej 12 mm/h dla kobiet i powyżej 8 mm/h dla mężczyzn', value: '192' }

  ];


  QuestionsList: Question[];
  SymptomsList: Symptom[];
  OtherAnswers:any[]=[];
  AnswersArray:any[] =[];
  SelectedArray:any[]=[];
  isDone : boolean = false;
  isPreliminaryDone : boolean = false;
  iterator=0;
  FinalResults:any[]=[];



  ngOnInit(): void {
    this.getQuestionnaire();
    this.getSymptoms();
  }

  getQuestionnaire() {
    this.questionnaire.getQuestionnaire().subscribe(response => {
      this.QuestionsList = response;
    }, error => {
      console.log(error);
    })
  }

  getSymptoms() {
    this.disease.getSymptoms().subscribe(response => {
      this.SymptomsList = response;
    }, error => {
      console.log(error);
    })
  }

  addAnswer(answer: any){
    let temp="0";
    if(answer!==null){
      this.AnswersArray.push(answer);
    }else{
      this.AnswersArray.push(temp);
    }

    if(this.AnswersArray.length==this.QuestionsList.length){
      this.isDone=true;
      console.log(this.AnswersArray);
    }
    if(this.iterator<this.QuestionsList.length-1){
      this.iterator+=1;
      this.quizForm.controls['answers'].reset();

    }
  }

  get answers() {
    return this.quizForm.get('answers')

  }

  get selectedSymptoms() {
    return this.form.get('selectedSymptoms')

  }
  get otherSymptoms() {
    return this.form3.get('otherSymptoms')

  }

  onCheckboxChange(event: any) {

    const selectedSymptoms = (this.form.controls['selectedSymptoms'] as FormArray);
    if (event.target.checked) {
      this.SelectedArray.push(event.target.value);
    } else {
      const index = this.SelectedArray
      .indexOf(event.target.value);
      this.SelectedArray.splice(index, 1);
    }
  }

  onCheckboxChange2(event: any) {

    const otherSymptoms = (this.form3.controls['otherSymptoms'] as FormArray);
    if (event.target.checked) {
      this.OtherAnswers.push(event.target.value);
    } else {
      const index = this.OtherAnswers
      .indexOf(event.target.value);
      this.OtherAnswers.splice(index, 1);
    }
  }

  submit2() {
    console.log(this.OtherAnswers);
    this.countFinalResults();
  }

  submit1() {
    console.log(this.SelectedArray);
    this.isPreliminaryDone=true;
  }

  submit() {
    this.addAnswer(this.quizForm.value.answers)
  }


  countFinalResults() {
    this.SelectedArray.forEach(element => {
      if(element.includes(",")){
        let temp=element.split(",");
        temp.forEach((i: any) => {this.FinalResults.push(i)});
      }else{
        this.FinalResults.push(element);
      }

    });
    this.AnswersArray.forEach(element => {
      if(element.includes(",")&& element!=="0"){
        let temp=element.split(",");
        temp.forEach((i: any) => {this.FinalResults.push(i)});
      }else if(element!=="0"){
        this.FinalResults.push(element);
      }

    });

    this.FinalResults=this.FinalResults.concat(this.OtherAnswers);
    this.FinalResults= this.FinalResults.filter((value, index, self) => self.indexOf(value) === index);
    console.log(this.FinalResults);

  }

}
