using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colecao.model
{
    class Marca
    {
        public Marca(int codigo, String descricao)
        {
            this.codigo = codigo;
            this.descricao = descricao;
        }

        public int codigo { get; set; }

        public String descricao { get; set; }
    }
}
