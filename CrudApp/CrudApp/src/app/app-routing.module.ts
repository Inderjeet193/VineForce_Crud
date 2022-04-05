import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CountriesComponent } from './countries/countries.component';
import { StateComponent } from './state/state.component';

const routes: Routes = [
  {path:'',component:CountriesComponent},
  {path:'Country',component:CountriesComponent},
  {path:'States',component:StateComponent}


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
