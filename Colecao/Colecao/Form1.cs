using Colecao.control;
using Colecao.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Colecao
{
    public partial class Form1 : Form
    {
        ControlDBActionFigure controlDB;
        List<Marca> marcas;

        public Form1()
        {
            InitializeComponent();
            controlDB = new ControlDBActionFigure();
            marcas = new List<Marca>();

            criarMarcas();
            preencherComboMarca();
            carregarGrid();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        //Botão Gravar
        private void button1_Click(object sender, EventArgs e)
        {
            ActionFigure bonequinho = new ActionFigure();

            int codigo = txtCodigo.Text.Equals("") ? 0 : int.Parse(txtCodigo.Text);

            bonequinho.codigo = codigo;
            bonequinho.nome = txtNome.Text;
            bonequinho.qtde = int.Parse(txtQtde.Text);
            bonequinho.data_compra = dtDataCompra.Value;
            bonequinho.obsevacao = txtObservacao.Text;
            bonequinho.valor = float.Parse(txtValor.Text);
            bonequinho.marca = marcas[cbMarca.SelectedIndex];
            bonequinho.material = txtMaterial.Text;

            if (codigo == 0)
            {
                controlDB.Inserir(bonequinho);
            }
            else
            {
                controlDB.Atualizar(bonequinho);
            }

            carregarGrid();

            limparCampos();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            int codigo = txtCodigo.Text.Equals("") ? 0 : int.Parse(txtCodigo.Text);

            if (codigo == 0)
            {
                MessageBox.Show("Carregue um registro para excluir");
            }
            else
            {
                controlDB.Excluir(codigo);
            }

            carregarGrid();
            limparCampos();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void carregarGrid()
        {
            DataTable dt = controlDB.Consultar();

            gridActionFigure.DataSource = dt;
        }

        //Acredito que o mais correto seja ter uma tabela de marcas no banco de dados, porem por questão de tempo, fiz hardcoded
        private void criarMarcas()
        {
            marcas.Add(new Marca(0,"Marvel"));
            marcas.Add(new Marca(1, "DC"));
            marcas.Add(new Marca(2, "Games"));
            marcas.Add(new Marca(3, "Outros"));
        }

        private void preencherComboMarca()
        {
            foreach(Marca m in marcas)
            {
                cbMarca.Items.Insert(m.codigo, m.descricao);
            }

            cbMarca.SelectedIndex = 0;


        }

        private void preencherActionFigure(int codigo)
        {
            DataTable dt = controlDB.ConsultarEspecifico(codigo);
            ActionFigure bonequinho = new ActionFigure();

            foreach (DataRow dtr in dt.Rows)
            {
                if (dtr["codigo"].ToString().Equals(codigo.ToString()))
                {
                    txtCodigo.Text = dtr["codigo"].ToString();
                    txtNome.Text = dtr["nome"].ToString();
                    txtQtde.Text = dtr["qtde"].ToString();
                    dtDataCompra.Value = Convert.ToDateTime(dtr["data_compra"].ToString());
                    txtObservacao.Text = dtr["obsevacao"].ToString();
                    txtValor.Text = dtr["valor"].ToString();
                    cbMarca.SelectedIndex = int.Parse(dtr["marca"].ToString());
                    txtMaterial.Text = dtr["material"].ToString();
                }
            }
        }

        private void gridActionFigure_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int codigo = int.Parse(gridActionFigure["codigo", e.RowIndex].Value.ToString());

            preencherActionFigure(codigo);
        }

        private void limparCampos()
        {
            txtCodigo.Text = "";
            txtNome.Text = "";
            txtQtde.Text = "";
            dtDataCompra.Value = DateTime.Now;
            txtObservacao.Text = "";
            txtValor.Text = "";
            cbMarca.SelectedIndex = 0;
            txtMaterial.Text = "";
        }
    }
}
