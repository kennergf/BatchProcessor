import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { InputComponent } from './input/input.component';

import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { InputFormComponent } from './input/input-form/input-form.component';
import { InputGridComponent } from './input/input-grid/input-grid.component';
import { InputService } from './input/shared/input.service';
import { ConsultBatchComponent } from './consult-batch/consult-batch.component';

@NgModule({
  declarations: [
    AppComponent,
    InputComponent,
    InputFormComponent,
    InputGridComponent,
    ConsultBatchComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
  ],
  providers: [InputService],
  bootstrap: [AppComponent]
})
export class AppModule { }
