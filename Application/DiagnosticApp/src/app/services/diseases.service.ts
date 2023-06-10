import { HttpClient, HttpHeaders,HttpRequest,HttpEvent } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Disease } from '../_models/disease';
import { Symptom } from '../_models/symptom';
import { DiseaseSymptoms } from '../_models/disease_symptoms';

@Injectable({
  providedIn: 'root'
})
export class DiseasesService {

  constructor(private http: HttpClient) { }

  readonly BaseURL= environment.BaseURL;

  readonly getAllDiseases = this.BaseURL + "Diseases/GetAll";
  readonly getSingleDisease = this.BaseURL + "Diseases/GetSpecific/";
  readonly getAllSymptoms = this.BaseURL + "Symptoms/GetAll";
  readonly getSingleSymptom = this.BaseURL + "Symptoms/GetSpecific/";



  getDiseases() {
    return this.http.get<Disease[]>(this.getAllDiseases);
  }

  getDisease(id: number) {
    return this.http.get<Disease>(this.getSingleDisease+id);
  }

  getSymptoms() {
    return this.http.get<Symptom[]>(this.getAllSymptoms);
  }

  geSumptom(id: number) {
    return this.http.get<Symptom>(this.getSingleSymptom+id);
  }


}
