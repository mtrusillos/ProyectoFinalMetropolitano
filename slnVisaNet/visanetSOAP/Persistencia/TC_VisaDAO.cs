using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using visanetSOAP.Dominio;
using System.Data.SqlClient;

namespace visanetSOAP.Persistencia
{
    public class TC_VisaDAO
    {
        private string CadenaConexion = "Data Source=(local); Initial Catalog=DBVisa;Integrated Security=SSPI;";

        public bool ValidarPago(TC_Visa tarjetaConsulta)
        {
            string sql = "SELECT 1  FROM [dbo].[TC_VISA]" +
                "where ESTADO_TARJETA='A' and NRO_TARJETA=@NRO_TARJETA and CVV_TARJETA=@CVV_TARJETA and VENC_TARJETA=@VENC_TARJETA and TIT_TARJETA=@TIT_TARJETA and SALDO >= @MONTO_CARGA";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@NRO_TARJETA", tarjetaConsulta.NRO_TARJETA));
                    comando.Parameters.Add(new SqlParameter("@CVV_TARJETA", tarjetaConsulta.CVV_TARJETA));
                    comando.Parameters.Add(new SqlParameter("@VENC_TARJETA", tarjetaConsulta.VENC_TARJETA));
                    comando.Parameters.Add(new SqlParameter("@TIT_TARJETA", tarjetaConsulta.TIT_TARJETA));
                    comando.Parameters.Add(new SqlParameter("@MONTO_CARGA", tarjetaConsulta.MONTO_CARGA));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            
                            return RealizarPago(tarjetaConsulta);
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
        }
        public bool RealizarPago(TC_Visa tarjetaConsulta)
        {
            string sql = "UPDATE [dbo].[TC_VISA] SET SALDO=SALDO - @MONTO_CARGA " +
                                    "where NRO_TARJETA=@NRO_TARJETA";
            try
            {
                using (SqlConnection conexion = new SqlConnection(CadenaConexion)) { 
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@NRO_TARJETA", tarjetaConsulta.NRO_TARJETA));
                    comando.Parameters.Add(new SqlParameter("@MONTO_CARGA", tarjetaConsulta.MONTO_CARGA));
                    comando.ExecuteNonQuery();
                    return true;
                }
                }
            }
            catch (Exception)
            {
                return false;
            }
            

        }
    }
}