import { Component, OnInit } from '@angular/core';
import { Subscription, timer } from 'rxjs';
import { switchMap } from 'rxjs/operators';

import { GenerateService } from './../service/generate.service';
import { Batches } from './../../shared/model/batches.model';

@Component({
  selector: 'app-generate-grid',
  templateUrl: './generate-grid.component.html',
  styleUrls: ['./generate-grid.component.css']
})
export class GenerateGridComponent implements OnInit {
  public batches: Batches;
  subscription: Subscription;

  constructor(public service: GenerateService) { }

  ngOnInit(): void {
    this.subscription = timer(0, 2000).pipe(
      switchMap(() => this.service.getProgress())
    ).subscribe(data => this.batches = data);
  }

  ngOnDestroy(){
    this.subscription.unsubscribe();
  }

}
