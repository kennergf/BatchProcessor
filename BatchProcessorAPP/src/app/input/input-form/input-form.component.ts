import { Component, OnInit } from '@angular/core';
import { InputService } from './../shared/input.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-input-form',
  templateUrl: './input-form.component.html',
  styleUrls: ['./input-form.component.css']
})
export class InputFormComponent implements OnInit {

  constructor(public service: InputService ) { }

  ngOnInit(): void {
    this.resetForm();
  }

  //
  onSubmit(form: NgForm) {
    this.insertRecord(form);
  }
  
  insertRecord(form: NgForm) {
    this.service.postInput().subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshGrid();
      },
      err => { console.log(err); }
    )
  }
  //

  resetForm(form?: NgForm){
    if(form != null)
      form.form.reset();
    this.service.formData = {
      XBatches: 0,
      YNumbers: 0
    }
  }

}
