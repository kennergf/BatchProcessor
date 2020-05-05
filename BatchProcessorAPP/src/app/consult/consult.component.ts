import { Component, OnInit } from '@angular/core';
import { Subscription, timer } from 'rxjs';
import { switchMap } from 'rxjs/operators';

import { ConsultService } from './service/consult.service';

@Component({
  selector: 'app-consult',
  templateUrl: './consult.component.html',
  styleUrls: ['./consult.component.css']
})
export class ConsultComponent implements OnInit {
  //executions: Array<number>;
  subscription: Subscription;

  constructor(public service: ConsultService) { }

  ngOnInit(): void {
    this.service.getExecutions();
  }

}
