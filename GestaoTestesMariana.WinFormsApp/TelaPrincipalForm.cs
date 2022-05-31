using gestaoTestesMariana.Infra.Arquivos;
using gestaoTestesMariana.Infra.Arquivos.ModuloDisciplina;
using gestaoTestesMariana.Infra.Arquivos.ModuloMateria;
using gestaoTestesMariana.Infra.Arquivos.ModuloQuestao;
using gestaoTestesMariana.Infra.Arquivos.ModuloTeste;
using gestaoTestesMariana.Infra.BancoDados.ModuloDisciplina;
using gestaoTestesMariana.Infra.BancoDados.ModuloMateria;
using gestaoTestesMariana.Infra.BancoDados.ModuloQuestao;
using gestaoTestesMariana.Infra.BancoDados.ModuloTeste;
using gestaoTestesMariana.WinFormsApp.Compartilhado;
using gestaoTestesMariana.WinFormsApp.ModuloDisciplina;
using gestaoTestesMariana.WinFormsApp.ModuloMateria;
using gestaoTestesMariana.WinFormsApp.ModuloQuestao;
using gestaoTestesMariana.WinFormsApp.ModuloTeste;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GestaoTestesMariana.WinFormsApp
{   
    public partial class TelaPrincipalForm : Form
    {
        private ControladorBase controlador;
        private Dictionary<string, ControladorBase> controladores;


        public TelaPrincipalForm()
        {
            InitializeComponent();

            Instancia = this;

            labelRodape.Text = string.Empty;
            labelTipoCadastro.Text = string.Empty;


            InicializarControladores();
        }

        public static TelaPrincipalForm Instancia
        {
            get;
            private set;
        }

        public void AtualizarRodape(string mensagem)
        {
            labelRodape.Text = mensagem;
        }

        private void testesMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
        }

        private void disciplinasMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
        }

        private void questoesMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
        }

        private void materiasMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            controlador.Inserir();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            controlador.Editar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            controlador.Excluir();
        }


        private void ConfigurarBotoes(ConfiguracaoToolboxBase configuracao)
        {
            btnInserir.Enabled = configuracao.InserirHabilitado;
            btnEditar.Enabled = configuracao.EditarHabilitado;
            btnExcluir.Enabled = configuracao.ExcluirHabilitado;
           
        }

        private void ConfigurarTooltips(ConfiguracaoToolboxBase configuracao)
        {
            btnInserir.ToolTipText = configuracao.TooltipInserir;
            btnEditar.ToolTipText = configuracao.TooltipEditar;
            btnExcluir.ToolTipText = configuracao.TooltipExcluir;
            
        }

        private void ConfigurarTelaPrincipal(ToolStripMenuItem opcaoSelecionada)
        {
            var tipo = opcaoSelecionada.Text;

            controlador = controladores[tipo];

            ConfigurarToolbox();

            ConfigurarListagem();
        }

        private void ConfigurarToolbox()
        {
            ConfiguracaoToolboxBase configuracao = controlador.ObtemConfiguracaoToolbox();

            if (configuracao != null)
            {
                toolbox.Enabled = true;

                labelTipoCadastro.Text = configuracao.TipoCadastro;

                ConfigurarTooltips(configuracao);

                ConfigurarBotoes(configuracao);
            }
        }

        private void ConfigurarListagem()
        {
            AtualizarRodape("");

            var listagemControl = controlador.ObtemListagem();

            panelRegistros.Controls.Clear();

            listagemControl.Dock = DockStyle.Fill;

            panelRegistros.Controls.Add(listagemControl);
        }

        private void InicializarControladores()
        {
            var repositorioDisciplina = new RepositorioDisciplinaEmBancoDados();
            var repositorioMateria = new RepositorioMateriaEmBancoDados();
            var repositorioQuestao = new RepositorioQuestaoEmBancoDados();
            var repositorioTeste = new RepositorioTesteEmBancoDados();

            controladores = new Dictionary<string, ControladorBase>();

            controladores.Add("Disciplinas", new ControladorDisciplina(repositorioDisciplina, repositorioMateria));
            controladores.Add("Materias", new ControladorMateria(repositorioMateria, repositorioDisciplina));
            controladores.Add("Questões", new ControladorQuestao(repositorioQuestao, repositorioMateria, repositorioDisciplina));
            controladores.Add("Testes", new ControladorTeste(repositorioTeste, repositorioQuestao, repositorioMateria, repositorioDisciplina));
        }


    }
}
