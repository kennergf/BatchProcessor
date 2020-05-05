import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { Unit } from './../shared/model/unit.model';
import { ConsultService } from './../consult/service/consult.service';

@Component({
  selector: 'app-execution',
  templateUrl: './execution.component.html',
  styleUrls: ['./execution.component.css']
})
export class ExecutionComponent implements OnInit {
  id: string;
  //batches: Array<Array<Unit>>;

  constructor(private route: ActivatedRoute, public service: ConsultService) {
    route.params.subscribe(params => { this.id = params['id']; });
  }

  ngOnInit(): void {
    this.service.getBatchesByExecution(this.id);
  }

}
