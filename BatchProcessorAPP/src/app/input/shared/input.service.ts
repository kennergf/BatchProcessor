import { Injectable } from '@angular/core';
import { Input } from './input.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class InputService {
  formData: Input;
  readonly rootURL = 'http://localhost:5000/Processor';
  list: Input[];

  constructor(private http: HttpClient) { }

  postInput(){
    return this.http.post(this.rootURL + '/Execute', this.formData);
  }

  refreshGrid(){
    this.http.get(this.rootURL + '/GetProgress')
    .toPromise()
    .then(res => this.list = res as Input[]);
  }
}
