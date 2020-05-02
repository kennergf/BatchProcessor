import { Component, OnInit } from '@angular/core';
import { InputService } from './../shared/input.service';
import { BatchLot } from './../shared/batch-lot.model';
import { Batch } from './../shared/batch.model';

@Component({
  selector: 'app-input-grid',
  templateUrl: './input-grid.component.html',
  styleUrls: ['./input-grid.component.css']
})
export class InputGridComponent implements OnInit {

  public batchLot: BatchLot;

  constructor(public service: InputService) { }

  ngOnInit(): void {
    this.service.refreshGrid().subscribe(data => this.batchLot = data);
    console.log(this.batchLot);
  }

}
