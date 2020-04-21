using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Entity;
namespace Data
{
    public class DDetallePedido
    {
        public List<DetallePedido> GetDetallesPedidos(DetallePedido detallePedido)
        {
            SqlParameter[] parameters = null;
            string comandText = string.Empty;
            List<DetallePedido> detallePedidos = null;

            try
            {
                comandText = "USP_ListarDetalle";
                parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@IdPedido ", SqlDbType.Int);
                parameters[0].Value = detallePedido.Pedido.IdPedido;
                detallePedidos = new List<DetallePedido>();

                using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.Connection, "USP_ListarDetalle", CommandType.StoredProcedure, parameters))
                {
                    while (reader.Read())
                    {
                        detallePedidos.Add(new DetallePedido
                        {
                            Pedido = new Pedido { IdPedido = reader["idpedido"] != null ? Convert.ToInt32(reader["idpedido"]) : 0 },
                            IdPedido = reader["idproducto"] != null ? Convert.ToInt32(reader["idproducto"]) : 0,
                            PrecioUnidad = reader["preciounidad"] != null ? Convert.ToDecimal(reader["preciounidad"]) : 0,
                            Cantidad = reader["cantidad"] != null ? Convert.ToInt32(reader["cantidad"]) : 0,
                            Descuento = reader["descuento"] != null ? Convert.ToDecimal(reader["descuento"]) : 0,
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return detallePedidos;
        }
    }
}
