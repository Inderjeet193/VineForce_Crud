using ModelLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DBManager
    {

        string Conn = ConfigurationManager.ConnectionStrings["CrudApiConnectionString"].ConnectionString;
        public List<Countries> dl_GetCountries()
        {
            List<Countries> CountriesList = new List<Countries>();
            DataTable DT = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(Conn))
            {
               
                SqlCommand Cmd = new SqlCommand("sp_getCountries", sqlConnection);

                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandTimeout = 30;
               
                SqlDataAdapter ADP = new SqlDataAdapter();
                ADP.SelectCommand = Cmd;
                sqlConnection.Open();
                ADP.Fill(DT);
                CountriesList=ConvertTableToList<Countries>(DT);
                sqlConnection.Close();
                
            }

            return CountriesList;

        }

        public List<Countries> bl_InsertUpdateCountries(Countries Countries)
        {
            List<Countries> CountriesList = new List<Countries>();
            DataTable DT = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(Conn))
            {

                SqlCommand Cmd = new SqlCommand("Sp_insertUpdateCountries", sqlConnection);
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandTimeout = 30;
                Cmd.Parameters.AddWithValue("@CountryName", Countries.CountryName);
                Cmd.Parameters.AddWithValue("@CountryId", Countries.CountryId);
                SqlDataAdapter ADP = new SqlDataAdapter();
                ADP.SelectCommand = Cmd;
                sqlConnection.Open();
                ADP.Fill(DT);
                CountriesList = ConvertTableToList<Countries>(DT);
                sqlConnection.Close();

            }

            return CountriesList;
        }

        public  Countries  bl_getCountryById(string CountryId)
        {
             Countries  CountriesList = new  Countries ();
            DataTable DT = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(Conn))
            {

                SqlCommand Cmd = new SqlCommand("Sp_getCountryById", sqlConnection);
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandTimeout = 30; 
                Cmd.Parameters.AddWithValue("@CountryId", CountryId);
                SqlDataAdapter ADP = new SqlDataAdapter();
                ADP.SelectCommand = Cmd;
                sqlConnection.Open();
                ADP.Fill(DT);
                CountriesList = ConvertTableToObject<Countries>(DT);
                sqlConnection.Close();

            }

            return CountriesList;
        }

        public List<Countries> bl_InsertUpdatestate(State state)
        {
            List<Countries> CountriesList = new List<Countries>();
            DataTable DT = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(Conn))
            {

                SqlCommand Cmd = new SqlCommand("Sp_insertUpdateStates", sqlConnection);
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandTimeout = 30;
                Cmd.Parameters.AddWithValue("@StateName", state.StateName);
                Cmd.Parameters.AddWithValue("@CountryId", state.CountryId);
                Cmd.Parameters.AddWithValue("@StateId", state.StateId);
                SqlDataAdapter ADP = new SqlDataAdapter();
                ADP.SelectCommand = Cmd;
                sqlConnection.Open();
                ADP.Fill(DT);
                CountriesList = ConvertTableToList<Countries>(DT);
                sqlConnection.Close();

            }

            return CountriesList;
        }

        public List<State> bl_GetStates()
        {
            List<State> StateList = new List<State>();
            DataTable DT = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(Conn))
            {

                SqlCommand Cmd = new SqlCommand("sp_getStates", sqlConnection);

                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandTimeout = 30;

                SqlDataAdapter ADP = new SqlDataAdapter();
                ADP.SelectCommand = Cmd;
                sqlConnection.Open();
                ADP.Fill(DT);
                StateList = ConvertTableToList<State>(DT);
                sqlConnection.Close();

            }

            return StateList;

        }


        public State bl_getStateById(string CountryId)
        {
            State CountriesList = new State();
            DataTable DT = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(Conn))
            {

                SqlCommand Cmd = new SqlCommand("sp_getStateById", sqlConnection);
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandTimeout = 30;
                Cmd.Parameters.AddWithValue("@StateId", CountryId);
                SqlDataAdapter ADP = new SqlDataAdapter();
                ADP.SelectCommand = Cmd;
                sqlConnection.Open();
                ADP.Fill(DT);
                CountriesList = ConvertTableToObject<State>(DT);
                sqlConnection.Close();

            }

            return CountriesList;
        }

        public List<State> bl_DeleteState(string StateId)
        {
            List<State> CountriesList = new List<State>();
            DataTable DT = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(Conn))
            {

                SqlCommand Cmd = new SqlCommand("Sp_inActiveState", sqlConnection);
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandTimeout = 30;
                Cmd.Parameters.AddWithValue("@StateId", StateId);
                SqlDataAdapter ADP = new SqlDataAdapter();
                ADP.SelectCommand = Cmd;
                sqlConnection.Open();
                ADP.Fill(DT);
                CountriesList = ConvertTableToList<State>(DT);
                sqlConnection.Close();

            }

            return CountriesList;
        }

        public List<Countries> bl_DeleteCountry(string CountryId)
        {
            List<Countries> CountriesList = new List<Countries>();
            DataTable DT = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(Conn))
            {

                SqlCommand Cmd = new SqlCommand("Sp_inActiveCountry", sqlConnection);
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandTimeout = 30;
                Cmd.Parameters.AddWithValue("@CountryId", CountryId);
                SqlDataAdapter ADP = new SqlDataAdapter();
                ADP.SelectCommand = Cmd;
                sqlConnection.Open();
                ADP.Fill(DT);
                CountriesList = ConvertTableToList<Countries>(DT);
                sqlConnection.Close();

            }

            return CountriesList;
        }

        public List<T> ConvertTableToList<T>(DataTable DT)
        {
            List<T> List = new List<T>();

            foreach (DataRow row in DT.Rows)
            {
                T item = GetItem<T>(row);
                List.Add(item);
            }
            return List;
        }
        public  T  ConvertTableToObject<T>(DataTable DT)
        {
            List<T> List = new List<T>();

            foreach (DataRow row in DT.Rows)
            {
                T item = GetItem<T>(row);
                List.Add(item);
            }
            return List[0];
        }
        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }

    }

    

}
