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
  { path: 'consult', component: ConsultComponent },
  { path: 'execution/:id', component: ExecutionComponent }
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
  providers: [
    { provide: "API_URL", useValue: "http://localhost:5000/Processor" },
    { provide: "ERROR_MSG_API", useValue: "Could not connect to the API, please verify the connection!" }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
