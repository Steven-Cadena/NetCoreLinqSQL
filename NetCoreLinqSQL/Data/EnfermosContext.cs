using NetCoreLinqSQL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreLinqSQL.Data
{
    public class EnfermosContext
    {
        private SqlDataAdapter adenfermo;
        private DataTable tablaenfermo;

        SqlCommand comand;
        SqlConnection cn;

        public EnfermosContext() 
        {
            string cadenaconexion = @"Data Source=LOCALHOST;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Password=MCSD2021";
            string sql = "select * from enfermo";
            this.adenfermo = new SqlDataAdapter(sql, cadenaconexion);
            this.tablaenfermo = new DataTable();
            this.adenfermo.Fill(tablaenfermo);


            this.comand = new SqlCommand();
            this.cn = new SqlConnection(cadenaconexion);
            this.comand.Connection = this.cn;
        }

        public List<Enfermo> GetEnfermos()
        {
            var consulta = from datos in this.tablaenfermo.AsEnumerable()
                           select datos;
            List<Enfermo> enfermos = new List<Enfermo>();
            foreach (var row in consulta) 
            {
                Enfermo enfermo = new Enfermo();
                enfermo.Inscripcion = row.Field<string>("INSCRIPCION");
                enfermo.Apellido = row.Field<string>("APELLIDO");
                enfermo.Direccion = row.Field<string>("DIRECCION");
                enfermo.NSS = row.Field<string>("NSS");
                enfermos.Add(enfermo);
            }
            return enfermos;
        }

        public int DeleteEnfermo() 
        { 
        
        }
    }
}
