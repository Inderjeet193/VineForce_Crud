import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { CountriesComponent } from './countries/countries.component'
import { FormsModule, ReactiveFormsModule} from '@angular/forms';
import { StateComponent } from './state/state.component';

import {MatCardModule} from '@angular/material/card';
import  {MatButtonModule} from '@angular/material/button';
import  {MatInputModule} from '@angular/material/input';
import {MatToolbarModule} from '@angular/material/toolbar'; 
import {MatTableModule} from '@angular/material/table';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
  declarations: [
    AppComponent,
    CountriesComponent,
    StateComponent
  ],
  imports: [
    BrowserModule,FormsModule,  ReactiveFormsModule,
    AppRoutingModule,HttpClientModule,AppRoutingModule,
    MatCardModule,MatButtonModule,MatInputModule,BrowserAnimationsModule,
    MatToolbarModule,MatTableModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
