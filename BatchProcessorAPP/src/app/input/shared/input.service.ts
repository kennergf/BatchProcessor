import { Injectable } from '@angular/core';
import { Input } from './input.model';
import { BatchLot } from './batch-lot.model';
import { HttpClient } from '@angular/common/http';

import { Observable, throwError } from 'rxjs';
import { map, catchError } from 'rxjs/operators';

//const timeInterval$ = interval(2000);

@Injectable({
  providedIn: 'root'
})
export class InputService {
  formData: Input;
  readonly rootURL = 'http://localhost:5000/Processor';
  grid: BatchLot;

  constructor(private http: HttpClient) { }

  postInput(){
    return this.http.post(this.rootURL + '/Execute', this.formData);
  }

  refreshGrid(){
    return this.http.get<BatchLot>(this.rootURL + '/GetProgress')
      .pipe(map(data => new BatchLot().deserialize(data)),
      catchError(()=> throwError('Error request or deserialize')));
    // timer(0, 2000).pipe(
    //   switchMap(_ => this.http.get(this.rootURL + '/GetProgress')),
    //   // .toPromise()
    //   // .then(res => this.grid = res as BatchLot)),
    //   catchError(error => of(`Bad request: ${error}`))
    // );
  }
}
