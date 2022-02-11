﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CursoWindowsFormsBiblioteca.Databases
{
    public class LocalDBClass
    {
        public String stringConn;
        public SqlConnection connDB;

        public LocalDBClass()
        {

            try
            {
                stringConn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\wande\\Desktop\\MyProjects\\Curso-WForms\\CursoWindowsForms\\CursoWindowsFormsBiblioteca\\Databases\\Fichario.mdf;Integrated Security=True";
                connDB = new SqlConnection(stringConn);
                connDB.Open();
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable SQLQuery(string SQL)
        {
            DataTable dt = new DataTable();
            try
            {
                var myCommand = new SqlCommand(SQL, connDB);
                myCommand.CommandTimeout = 0;
                var myReader = myCommand.ExecuteReader();
                dt.Load(myReader);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;
        }

        public string SQLCommand(String SQL)
        {
            try
            {
                var myCommand = new SqlCommand(SQL, connDB);
                myCommand.CommandTimeout = 0;
                var myReader = myCommand.ExecuteReader();
                return "";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void CloseConnection()
        {
            connDB.Close();
        }
    }
}


