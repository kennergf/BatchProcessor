import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

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
  providers: [/* GenerateService */],
  bootstrap: [AppComponent]
})
export class AppModule { }
