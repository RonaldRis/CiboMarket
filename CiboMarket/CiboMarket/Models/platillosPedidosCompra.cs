using CiboMarket.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cibo.Models
{
    class platillosPedidosCompra
    {
        public platillosPedidos platiPedido { get; set; }
        public platillos plati { get; set; }

        public platillosPedidosCompra(platillosPedidos p)
        {
            this.platiPedido = p;

            LocalSQLITE DB = new LocalSQLITE();

        }

    }
}
