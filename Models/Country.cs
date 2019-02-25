using System.Collections.Generic;
using System;
using MySql.Data.MySqlClient;

namespace WorldDatabase.Models
{
    public class Country
    {
        private string _code;
        private string _name;
        private string _continent;
        private string _region;
        private float _surfaceArea;
        private int _population;

        public Country (string code, string name, string continent, string region, float surfaceArea, int population)
        {
            _code = code;
            _name = name;
            _continent = continent;
            _region = region;
            _surfaceArea = surfaceArea;
            _population = population;
        }
        public string GetCode()
        {
            return _code;
        }
        public void SetCode(string newCode)
        {
            _code = newCode;
        }
        public string GetName()
        {
            return _name;
        }
        public void SetName(string newName)
        {
            _name = newName;
        }
        public string GetContinent()
        {
            return _continent;
        }
        public void SetContinent(string newContinent)
        {
            _continent = newContinent;
        }
        public string GetRegion()
        {
            return _region;
        }
        public void SetRegion(string newRegion)
        {
            _region = newRegion;
        }
        public float GetSurfaceArea()
        {
            return _surfaceArea;
        }
        public void SetSurfaceArea(float newSurfaceArea)
        {
            _surfaceArea = newSurfaceArea;
        }
        public int GetPopulation()
        {
            return _population;
        }
        public void SetPopulation(int newPopulation)
        {
            _population = newPopulation;
        }

        public static List<Country> GetAll()
        {
            List<Country> allCountries = new List<Country> {};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT Code, Name, Continent, Region, SurfaceArea, Population FROM country;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
                string countryCode = rdr.GetString(0);
                string countryName = rdr.GetString(1);
                string countryContinent = rdr.GetString(2);
                string countryRegion = rdr.GetString(3);
                float countrySurfaceArea = rdr.GetFloat(4);
                int countryPopulation = rdr.GetInt32(5);
                Country newCountry = new Country(countryCode, countryName, countryContinent, countryRegion, countrySurfaceArea, countryPopulation);
                allCountries.Add(newCountry);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allCountries;
        }
    }
}