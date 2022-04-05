import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http'; 
import {Observable} from 'rxjs'
import{Country} from '../Models/country';
import { State } from '../Models/state';
@Injectable({
  providedIn: 'root'
})
export class CountriesService {

    //Web API URL
    ApiUrl: string='http://localhost:52339/';
  constructor(private httpclient:HttpClient) { }

  //Country region: All Methods releated to CRUD operation on Country
  GetAllCountries(){
     
    return this.httpclient.get<Country>(this.ApiUrl+'countries/getCountries');
  }
  AddCountry(country: Country): Observable<Country> {  
     
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };  
    return this.httpclient.post<Country>(this.ApiUrl + 'countries/AddCountry/',  
    country, httpOptions);  
  }  
  getCountryById(CountryId: string): Observable<Country> {  
    
    return this.httpclient.get<Country>(this.ApiUrl+'countries/getCountryById/'+CountryId);
  } 
  
  DeleteCountryById(CountryId: string): Observable<Country> {  
   
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) }; 
    return this.httpclient.post<Country>(this.ApiUrl+'countries/DeleteCountry/'+CountryId,httpOptions);
  } 

//End Country region

//State Region : All api methods used for crud on State 
  GetAllStates(){
     
    return this.httpclient.get<State>(this.ApiUrl+'states/getStates');
  }

  AddState(state:State)
  {
   
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };  
    return this.httpclient.post<Country>(this.ApiUrl + 'states/AddState/',  
    state, httpOptions);
  }

  getStateById(stateId: string): Observable<State> {  
    
    return this.httpclient.get<State>(this.ApiUrl+'states/getStateById/'+stateId);
  } 

  DeleteStateById(stateId: string): Observable<State> {  
    
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) }; 
    return this.httpclient.post<State>(this.ApiUrl+'states/DeleteState/'+stateId,httpOptions);
  } 

  //End State Region
 
}
