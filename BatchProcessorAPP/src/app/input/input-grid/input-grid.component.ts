import { Component, OnInit } from '@angular/core';
import { InputService } from './../shared/input.service';
import { BatchLot } from './../shared/batch-lot.model';
import { Subscription, timer } from 'rxjs';
import { switchMap } from 'rxjs/operators';

@Component({
  selector: 'app-input-grid',
  templateUrl: './input-grid.component.html',
  styleUrls: ['./input-grid.component.css']
})
export class InputGridComponent implements OnInit {

  public batchLot: BatchLot;
  subscription: Subscription;

  constructor(public service: InputService) { }

  ngOnInit(): void {
    this.subscription = timer(0, 2000).pipe(
      switchMap(() => this.service.refreshGrid())
    ).subscribe(data => this.batchLot = data);
    //this.service.refreshGrid().subscribe(data => this.batchLot = data);
  }

  ngOnDestroy(){
    this.subscription.unsubscribe();
  }

}
