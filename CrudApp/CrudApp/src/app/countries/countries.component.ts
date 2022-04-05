import { Component, OnInit } from '@angular/core';
import { CountriesService } from '../service/countries.service';
import { FormBuilder, Validators } from '@angular/forms';  
import{Country} from '../Models/country';
@Component({
  selector: 'app-countries',
  templateUrl: './countries.component.html',
  styleUrls: ['./countries.component.css']
})
export class CountriesComponent implements OnInit {

  public Countries:any ;dataSaved:boolean=false;
  countryForm: any;  massage='';CountryID='';
  constructor(private Api:CountriesService,private formbulider: FormBuilder) { }

  ngOnInit(): void {
    this.countryForm = this.formbulider.group({  
      countryName: ['', [Validators.required]], 
       
    });  
  this.LoadAllCountries();
  }
  LoadAllCountries(){
  
    this.Api.GetAllCountries().subscribe(data=>
      {  
        this.Countries=data as any;
      });
      this.CountryID ='';
      
  }
  onFormSubmit() {  
    this.massage=''
    this.dataSaved = false;  
    const country = this.countryForm.value; 
  debugger; 
    if(!country.countryName )
    {
      
    this.dataSaved = false;  
    this.massage = 'Country name is required.'; 
    return;
    }
    //check whether it's a request to update existing country details or add new country
    if(this.CountryID!='')
    {
      this.UpdateCountryName(country); 
    }
    else{
    this.AddCountrty(country); 
    } 
 
    this.countryForm.reset();  
    this.LoadAllCountries();
  }  

  // add new country
  AddCountrty(country:Country)
  {
     
    
    this.Api.AddCountry(country).subscribe(  
      () => {  
        this.dataSaved = true;  
        this.massage = 'Record saved Successfully';  
        this.LoadAllCountries();  
        this.countryForm.reset;  
       
      }  
    );
  }

  //fetch country details for edit using country id
  EditCountry( Id: string) {  
   
    this.Api.getCountryById(Id).subscribe(data=> {  
      this.massage = '';  
      this.dataSaved = false;  
      this.CountryID = data.CountryId;  
      this.countryForm.controls['countryName'].setValue(data.CountryName);   
    })
  };  
  //update country details
  UpdateCountryName(country:Country) {  
     
    country.CountryId=this.CountryID;
    this.Api.AddCountry(country).subscribe(  
      () => {  
        this.dataSaved = true;  
        this.massage = 'Record updated Successfully';  
        this.countryForm.reset; 
        this.LoadAllCountries();  
       
         
      }  
    );
  }

  //delete country using country id
DeleteCountryById( Id: string) {  
 
  this.Api.DeleteCountryById(Id).subscribe(data=> {  
    this.dataSaved=true;
    this.massage='Record deleted successfully.'
    this.LoadAllCountries();
    this.countryForm.reset; 
    
  })
};  
};
