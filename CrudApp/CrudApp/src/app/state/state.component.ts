import { Component, OnInit } from '@angular/core';
import { FormBuilder,Validators } from '@angular/forms';
import { State } from '../Models/state';
import { CountriesService } from '../service/countries.service';
 
@Component({
  selector: 'app-state',
  templateUrl: './state.component.html',
  styleUrls: ['./state.component.css']
})
export class StateComponent implements OnInit {
  States:any;stateForm:any;
  Countries:any;dataSaved=false;Message='';StateID='0';
  constructor(private API:CountriesService,private formbulider:FormBuilder) { }

  ngOnInit(): void {
    
    this.InitializeForm();
    this.LoadAllCountries();
  }

InitializeForm()
{
  this.API.GetAllStates().subscribe(data=>{
    this.States=data
  });
  this.stateForm = this.formbulider.group({  
    countryName: ['', [Validators.required]], 
    stateName: ['', [Validators.required]], 
    CountryId: ['0', [Validators.required]], 
  });
  this.LoadAllCountries(); 
  this.StateID='';
}
LoadAllCountries(){
  
  this.API.GetAllCountries().subscribe(data=>
    { 
      this.Countries=data;
    });
   
}

//on form submit function
onFormSubmit()
{
  this.dataSaved = false;  
    const state = this.stateForm.value;  
    if(!state.stateName )
    {
      this.Message='State name is required.'
      return;
    }
    if (state.CountryId=='0')
    {
      
      this.Message='Please select country name.'
      return;
    }
    //check whether it's a command for update state details or add new state
    if(this.StateID!='')
    {
      this.UpdateStateDetails(state); 
    }
    else{
      this.AddState(state);
    } 
   
    this.stateForm.reset();  
   
}

// Add new state
AddState(state:State){
  this.API.AddState(state).subscribe(data=>{
    this.dataSaved=true;
    this.Message='Record saved successfully.'
    this.stateForm.reset;
    this.InitializeForm();
    
  })
}

//Get state details for edit
EditState( Id: string) {  
  
  this.API.getStateById(Id).subscribe(data=> {  
    this.Message = '';  
    this.dataSaved = false;  
    this.StateID = data.StateId;  
    this.stateForm.controls['stateName'].setValue(data.StateName);   
    this.stateForm.controls['CountryId'].setValue(data.CountryId);  
  })
};  

//update state details
UpdateStateDetails(state:State) {  
   
  state.StateId=this.StateID;
  this.API.AddState(state).subscribe(  
    () => {  
      this.dataSaved = true;  
      this.Message = 'Record updated Successfully';  
      this.stateForm.reset;
      this.InitializeForm(); 
    }  
  );
}

//delete state using state id
DeleteStateById( Id: string) {  
 
  this.API.DeleteStateById(Id).subscribe(data=> {  
    this.dataSaved=true;
    this.Message='Record deleted successfully.'
    this.stateForm.reset;
    this.InitializeForm();
  })
};

}
