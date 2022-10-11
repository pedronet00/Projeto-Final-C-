using Repositorio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace projeto_final.Cadastro
{
    public partial class Clientes : Form
    {
        public Clientes()
        {
            InitializeComponent();

            this.txtCodigo.Enabled = false;
            this.habilitarCampos(true);
            this.controlarBotoes(OperadorEnum.inicial);

            this.btnInserir.Click += this.eventoBotaoNovoClick;
            this.btnExcluir.Click += this.eventoBotaoDeletarClick;
            this.btnRecuperar.Click += this.eventoBotaoRecuperarClick;
           // this.btnSalvar.Click += this.eventoBotaoSalvarClick;
        }

        private void limparCampos()
        {
            this.txtCodigo.Clear();
            this.txtCidade.Clear();
            this.txtCPF.Clear();
            this.txtEndereco.Clear();
            this.txtIdade.Clear();
            this.txtSexo.Clear();
            this.txtTelefone.Clear();
            this.txtEmail.Clear();
            this.txtNome.Clear();
        }

        private void habilitarCampos(bool habilita)
        {
            this.txtNome.Enabled = habilita;
        }

        private void controlarBotoes(OperadorEnum acao)
        {

            btnExcluir.Enabled = false;
            btnInserir.Enabled = false;
            btnRecuperar.Enabled = false;
            btnSalvar.Enabled = false;

            if (acao == OperadorEnum.alterar)
            {
                btnSalvar.Enabled = true;
                btnExcluir.Enabled = true;

            }
            else
            {
                if (acao == OperadorEnum.inserir)
                {
                    btnInserir.Enabled = true;
                    btnSalvar.Enabled = true;
                }
                else
                {

                    if(acao == OperadorEnum.inicial)
                   {
                        btnInserir.Enabled = true;
                        btnRecuperar.Enabled = true;
                        btnSalvar.Enabled = true;
                    }
                }
            }
        }



        private void eventoBotaoNovoClick(object sender, EventArgs e)
        {
            txtCodigo.Enabled = false;

            txtCodigo.Text = "0";

            this.controlarBotoes(OperadorEnum.inserir);

            this.habilitarCampos(true);

            txtNome.Focus();
        }
    
        private void eventoBotaoDeletarClick(object sender, EventArgs e)
        {
            int id = int.Parse(txtCodigo.Text);

            var repositorio = new RepositorioCliente();

            var obj = repositorio.recuperarPorId(id);

            if(obj != null)
            {
                var sucesso = repositorio.remover(id);

                if (sucesso)
                {
                    MessageBox.Show("Excluído com sucesso");
                }
                else
                {
                    MessageBox.Show("Erro ao excluir. Tente novamente mais tarde");
                }
            }
            else
            {
                MessageBox.Show("O Cliente não existe");
            }

            this.controlarBotoes(OperadorEnum.inicial);

            this.habilitarCampos(false);

            this.limparCampos();
        }
    
        private void eventoBotaoCancelarClick(object sender, EventArgs e)
        {
            this.controlarBotoes(OperadorEnum.inicial);
            this.habilitarCampos(false);
            this.limparCampos();
        }

        private void eventoBotaoRecuperarClick(object sender, EventArgs e)
        {

            using (var frm = new Consulta.ConsultaCliente())
            {
                frm.ShowDialog();

                var id = frm.obterIdSelecionado();

                txtCodigo.Text = id.ToString();

                this.controlarBotoes(OperadorEnum.alterar);

                this.habilitarCampos(true);

                this.carregarDados(id);

                txtNome.Focus();
            }
        }


        private void carregarDados(int id)
        {
            var repositorio = new RepositorioCliente();

            var obj = repositorio.recuperarPorId(id);

            if(obj != null)
            {
                txtNome.Text = obj.Nome;
            }
        }

        private void Clientes_Load(object sender, EventArgs e)
        {

        }
    }
}
