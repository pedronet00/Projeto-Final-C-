﻿using System;
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
    public partial class ConsultaFuncionarios : Form
    {
        public ConsultaFuncionarios()
        {
            InitializeComponent();
        }

        private void ConsultaFuncionarios_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'projeto2022DataSet.Funcionario'. Você pode movê-la ou removê-la conforme necessário.
            this.funcionarioTableAdapter.Fill(this.projeto2022DataSet.Funcionario);

        }
    }
}