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

        SqlCommand com;
        SqlConnection cn;

        public EnfermosContext() 
        {
            string cadenaconexion = @"Data Source=LOCALHOST;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Password=MCSD2021";
            this.cn = new SqlConnection(cadenaconexion);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
            this.RefreshData();
        }
        private void RefreshData() 
        {
            string cadenaconexion = @"Data Source=LOCALHOST;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Password=MCSD2021";
            string sql = "select * from enfermo";
            this.adenfermo = new SqlDataAdapter(sql, cadenaconexion);
            this.tablaenfermo = new DataTable();
            this.adenfermo.Fill(tablaenfermo);
        }

        public List<Enfermo> GetEnfermos()
        {
            var consulta = from datos in this.tablaenfermo.AsEnumerable()
                           select datos;
            List<Enfermo> enfermos = new List<Enfermo>();
            foreach (var row in consulta) 
            {
                Enfermo enfermo = new Enfermo();
                enfermo.Inscripcion = row.Field<int>("INSCRIPCION");
                enfermo.Apellido = row.Field<string>("APELLIDO");
                enfermo.FechaNacimiento = row.Field<DateTime>("FECHA_NAC");
                enfermo.Direccion = row.Field<string>("DIRECCION");
                enfermo.NSS = row.Field<string>("NSS");
                enfermos.Add(enfermo);
            }
            return enfermos;
        }

        public int EliminarEnfermo(int inscripcion) 
        {
            string sql = "delete from enfermo where inscripcion= @inscripcion";
            this.com.Parameters.AddWithValue("@inscripcion", inscripcion);
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            int eliminados = this.com.ExecuteNonQuery();
            this.cn.Close();
            this.com.Parameters.Clear();
            this.RefreshData();
            return eliminados;
        }
    }
}
