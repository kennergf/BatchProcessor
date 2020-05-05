import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';

import { GenerateService } from './../service/generate.service';

@Component({
  selector: 'app-generate-form',
  templateUrl: './generate-form.component.html',
  styleUrls: ['./generate-form.component.css']
})
export class GenerateFormComponent implements OnInit {

  constructor(public service: GenerateService) { }

  ngOnInit(): void {
    this.resetForm();
  }

  resetForm(form?: NgForm){
    if(form != null)
      form.form.reset();
    this.service.formData = {
      XBatches: null,
      YNumbers: null
    }
  }

  onSubmit(form: NgForm) {
    this.service.postInput().subscribe(
      res => {
        this.resetForm(form);
        this.service.getProgress();
      },
      err => { console.log(err); }
    )
  }

}
