using DataLayer;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BusinessLogic
    {

        DBManager dBManager = new DBManager();

        public List<Countries> bl_GetCountries()
        {
            return dBManager.dl_GetCountries();
        }
        public List<Countries> bl_AddCountries(Countries Countries)
        {
            return dBManager.bl_InsertUpdateCountries(Countries);
        }

        public  Countries  bl_getCountryById(string CountryId)
        {
            return dBManager.bl_getCountryById( CountryId);
        }
        public List<State> bl_GetStates()
        {
            return dBManager.bl_GetStates();
        }


        public List<Countries> bl_Addstate(State state)
        {
            return dBManager.bl_InsertUpdatestate(state);
        }

        public State bl_getStateById(string stateId)
        {
            return dBManager.bl_getStateById(stateId);
        }

        public List<State> bl_DeleteState(string stateId)
        {
            return dBManager.bl_DeleteState(stateId);
        }


        public List<Countries> bl_DeleteCountry(string CountryId)
        {
            return dBManager.bl_DeleteCountry(CountryId);
        }
    }
}
