import { Component, OnInit } from '@angular/core';

import { Unit } from './../shared/model/unit.model';

@Component({
  selector: 'app-execution',
  templateUrl: './execution.component.html',
  styleUrls: ['./execution.component.css']
})
export class ExecutionComponent implements OnInit {
  batches: Array<Array<Unit>>;

  constructor() { }

  ngOnInit(): void {
  }

}
