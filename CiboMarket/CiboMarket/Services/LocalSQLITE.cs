using CiboMarket.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Cibo.Models
{
    public class LocalSQLITE
    {

        public SQLiteAsyncConnection conexion { get; set; }

        public LocalSQLITE()
        {
            string sqlDBname = "platillos_compra_proceso.db3";
            string ubicacion = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), sqlDBname);
            try
            {
                conexion = new SQLiteAsyncConnection(ubicacion);
                conexion.CreateTableAsync<platillos>().Wait();
                conexion.CreateTableAsync<pedidos>().Wait();
                conexion.CreateTableAsync<platillosPedidos>().Wait();
            }
            catch (Exception x)
            {
                Debug.Print("LocalSQLITE ERROR: " + x.Message);
            }

        }



        public void MapearVerificarCrearPlatillosLocalesApi(platillos plati) {


            try
            {

                List<platillos> borraresto = conexion.QueryAsync<platillos>("Select * FROM platillos").Result;
                List<platillos> intentoWhereID = conexion.QueryAsync<platillos>("Select * FROM [platillos] WHERE idPlatillo=?", plati.idPlatillo).Result;
                
                if (intentoWhereID.Count == 0)
                {
                    //No existe el platillo en la base de datos, que lo cree
                   
                    plati.cant = 0;
                    plati.subtotal = 0;
                    if (conexion.InsertAsync(plati).Result == 1)//GUARDO EL OBJETO TAL CUAL
                    {
                        Debug.Print(plati.nombre + " GUARDADO localmente");
                    }
                }
                else
                {
                    Debug.Print(plati.nombre + " Ya existe localmente");
                }

            }
            catch (Exception notSqlQuery) { Debug.Print("notSqlQuery:   --- " + notSqlQuery.Message); }

        }

    }
}
