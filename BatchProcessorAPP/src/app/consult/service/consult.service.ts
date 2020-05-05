import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { Unit } from 'src/app/shared/model/unit.model';

@Injectable({
  providedIn: 'root'
})
export class ConsultService {
  readonly rootURL = 'http://localhost:5000/Processor';
  executions: Array<number>;
  batches: Array<Array<Unit>>;

  constructor(private http: HttpClient) { }

  getExecutions() {
    return this.http.get<Array<number>>(this.rootURL + '/GetExecutions')
    .toPromise()
    .then(data => this.executions = data as Array<number>),
        catchError(() => throwError('Error on request or deserialize'));
  }

  getBatchesByExecution(id: string){
    return this.http.get<Array<Array<Unit>>>(this.rootURL + '/GetBatchesByExecution?Id=' + id)
    .toPromise()
    .then(data => this.batches = data as Array<Array<Unit>>),
        catchError(() => throwError('Error on request or deserialize'));
  }
}
