using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colecao.model
{
    abstract class Item
    {
        public int codigo { get; set; }

        public String nome { get; set; }

        public int qtde { get; set; }

        public DateTime data_compra { get; set; }

        public String obsevacao { get; set; }
    }
}
