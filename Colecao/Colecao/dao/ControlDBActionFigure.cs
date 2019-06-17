using Colecao.dao;
using Colecao.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colecao.control
{
    class ControlDBActionFigure
    {

        Conection conDB = new Conection();

        public void Inserir(ActionFigure bonequinho)
        {
            String comando = "Insert into actionFigure(nome, qtde, data_compra, obsevacao, valor, marca, material) " +
                             "values ('" + bonequinho.nome + "'," 
                             + bonequinho.qtde + ",'" 
                             + bonequinho.data_compra+ "','"
                             + bonequinho.obsevacao + "'," 
                             + bonequinho.valor +"," 
                             + bonequinho.marca.codigo +",'" 
                             + bonequinho.material+ "')";
            conDB.manipularDados(comando);
        }

        public void Atualizar(ActionFigure bonequinho)
        {
            String comando = "update actionFigure " +
                            "set nome = '" + bonequinho.nome + "'," +
                                "qtde = " + bonequinho.qtde + "," +
                                "data_compra  = '"+ bonequinho.data_compra+ "'," +
                                "obsevacao = '"+ bonequinho.obsevacao + "'," +
                                "valor = " + bonequinho.valor + "," +
                                "marca = "+ bonequinho.marca.codigo +"," +
                                "material = '"+ bonequinho.material+ "'" +
                             "where codigo = " + bonequinho.codigo ;
            conDB.manipularDados(comando);
        }

        public void Excluir(int codigo)
        {
            String comando = "Delete from actionFigure where codigo = (" + codigo + ")";
            conDB.manipularDados(comando);
        }

        public DataTable Consultar()
        {
            String comando = "Select * from actionFigure";
            return conDB.colsultarDados(comando);
        }

        public DataTable ConsultarEspecifico(int codigo)
        {
            String comando = "Select * from actionFigure where codigo = "+ codigo + "";
            return conDB.colsultarDados(comando);
        }
    }
}
