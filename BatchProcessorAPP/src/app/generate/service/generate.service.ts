import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { map, catchError } from 'rxjs/operators';

import { Input } from './../model/input.model';
import { Batches } from './../../shared/model/batches.model';

@Injectable({
  providedIn: 'root'
})
export class GenerateService {
  formData: Input;
  batches: Batches;

  constructor(
    private http: HttpClient,
    @Inject("API_URL") private apiUrl: string,
    @Inject("ERROR_MSG_API") private errorAPI: string
  ) { }

  postInput() {
    return this.http.post(this.apiUrl + '/Execute', this.formData);
  }

  getProgress() {
    return this.http.get<Batches>(this.apiUrl + '/GetProgress')
      .pipe(map(data => new Batches().deserialize(data)),
        catchError(() => throwError(this.errorAPI)));
  }
}
