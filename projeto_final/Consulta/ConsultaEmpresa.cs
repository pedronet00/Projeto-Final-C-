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
    public partial class ConsultaEmpresa : Form
    {
        public ConsultaEmpresa()
        {
            InitializeComponent();
        }

        private void ConsultaEmpresa_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'projeto2022DataSet.Empresa'. Você pode movê-la ou removê-la conforme necessário.
            this.empresaTableAdapter.Fill(this.projeto2022DataSet.Empresa);

        }
    }
}
