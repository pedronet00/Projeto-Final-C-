using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projeto_final.Consulta
{
    public partial class ConsultaCliente : Form
    {
        public ConsultaCliente()
        {
            InitializeComponent();

            this.carregarDados();

            this.dataGridViewClientes.CellDoubleClick += eventoDataGridViewClientesCellDoubleClick;
        }

       

        private int IdSelecionado = 0;

        public int obterIdSelecionado()
        {
            return this.IdSelecionado;
        }

        private void carregarDados()
        {
            var repositorio = new Repositorio.RepositorioCliente();

            dataGridViewClientes.DataSource = repositorio.listarTodos();

        }

        private void eventoDataGridViewClientesCellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.IdSelecionado = (int)dataGridViewClientes.Rows[e.RowIndex].Cells[0].Value;

            this.Close();
        }
    }
}
