import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { Unit } from 'src/app/shared/model/unit.model';

@Injectable({
  providedIn: 'root'
})
export class ConsultService {
  executions: Array<number>;
  batches: Array<Array<Unit>>;

  constructor(
    private http: HttpClient,
    @Inject("API_URL") private apiUrl: string,
    @Inject("ERROR_MSG_API") private errorAPI: string
  ) { }

  getExecutions() {
    return this.http.get<Array<number>>(this.apiUrl + '/GetExecutions')
      .toPromise()
      .then(data => this.executions = data as Array<number>),
      catchError(() => throwError(this.errorAPI));
  }

  getBatchesByExecution(id: string) {
    return this.http.get<Array<Array<Unit>>>(this.apiUrl + '/GetBatchesByExecution?Id=' + id)
      .toPromise()
      .then(data => this.batches = data as Array<Array<Unit>>),
      catchError(() => throwError(this.errorAPI));
  }
}
