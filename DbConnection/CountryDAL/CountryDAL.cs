using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DbConnection.CountryDAL
{
    public class CountryDAL
    {
        private readonly string _connectionString;

        public CountryDAL(IConfiguration iconfiguration)
        {
            _connectionString = iconfiguration.GetConnectionString("Default");
        }

        public List<CountryModel.CountryModel> GetList()
        {
            var listCountryModel = new List<CountryModel.CountryModel>();
            try
            {
                using (var con = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("SP_COUNTRY_GET_LIST", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    var rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                        listCountryModel.Add(new CountryModel.CountryModel
                        {
                            Id = Convert.ToInt32(rdr[0]),
                            Country = rdr[1].ToString(),
                            Active = Convert.ToBoolean(rdr[2])
                        });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return listCountryModel;
        }
    }
}

