import { HttpClient } from '@angular/common/http';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Observable } from 'rxjs';
import { DiseasesService } from 'src/app/services/diseases.service';
import { Subscription } from 'rxjs';
import { Disease } from 'src/app/_models/disease';

@Component({
  selector: 'app-diseases-list',
  templateUrl: './diseases-list.component.html',
  styleUrls: ['./diseases-list.component.scss']
})
export class DiseasesListComponent implements OnInit{

  constructor(private diseases: DiseasesService, private http: HttpClient) { }

  diseasesList: Disease[];
  disease: any;
  diseaseId: number =1;


  ngOnInit(): void {
    this.getDiseases();
    this.getDisease();

  }




  getDiseases() {
    this.diseases.getDiseases().subscribe(response => {
      this.diseasesList = response;
    }, error => {
      console.log(error);
    })
  }

  getDisease() {
    let id = this.diseaseId;
    this.diseases.getDisease(id).subscribe(response => {
      this.disease = response;

    }, error => {
      console.log(error);
    })
  }

}
