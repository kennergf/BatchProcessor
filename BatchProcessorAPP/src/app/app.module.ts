import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { InputComponent } from './input/input.component';
import { InputFormComponent } from './input/input-form/input-form.component';
import { InputGridComponent } from './input/input-grid/input-grid.component';
import { InputService } from './input/shared/input.service';
import { ConsultBatchComponent } from './consult-batch/consult-batch.component';

import { ConsultComponent } from './consult/consult.component';
import { GenerateComponent } from './generate/generate.component';
import { GenerateGridComponent } from './generate/generate-grid/generate-grid.component';
import { GenerateFormComponent } from './generate/generate-form/generate-form.component';
import { ExecutionComponent } from './execution/execution.component';

const routes: Routes = [
  { path: '', redirectTo: 'generate', pathMatch: 'full' },
  { path: 'generate', component: GenerateComponent },
  { path: 'consult', component: ConsultComponent }
]

@NgModule({
  declarations: [
    AppComponent,
    InputComponent,
    InputFormComponent,
    InputGridComponent,
    ConsultBatchComponent,
    ConsultComponent,
    GenerateComponent,
    GenerateGridComponent,
    GenerateFormComponent,
    ExecutionComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forRoot(routes),
  ],
  providers: [InputService],
  bootstrap: [AppComponent]
})
export class AppModule { }
