import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { map, catchError } from 'rxjs/operators';

import { Input } from './../model/input.model';
import { Batches } from './../../shared/model/batches.model';

@Injectable({
  providedIn: 'root'
})
export class GenerateService {
  readonly rootURL = 'http://localhost:5000/Processor';
  formData: Input;
  batches: Batches;

  constructor(private http: HttpClient) { }

  postInput() {
    return this.http.post(this.rootURL + '/Execute', this.formData);
  }

  getProgress() {
    return this.http.get<Batches>(this.rootURL + '/GetProgress')
      .pipe(map(data => new Batches().deserialize(data)),
        catchError(() => throwError('Error on request or deserialize')));
  }
}
