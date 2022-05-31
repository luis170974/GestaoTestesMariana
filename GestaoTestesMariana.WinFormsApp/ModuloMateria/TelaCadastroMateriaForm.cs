using gestaoTestesMariana.Dominio.ModuloMateria;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using gestaoTestesMariana.Dominio.ModuloDisciplina;
using GestaoTestesMariana.WinFormsApp;

namespace gestaoTestesMariana.WinFormsApp.ModuloMateria
{
    public partial class TelaCadastroMateriaForm : Form
    {
        IRepositorioDisciplina repositorioDisciplina;

        public TelaCadastroMateriaForm(IRepositorioDisciplina repositorioDisciplina)
        {
            InitializeComponent();
            this.repositorioDisciplina = repositorioDisciplina;
            CarregarDisciplinasComboBox();
            

        }

        private Materia materia;

        public List<Disciplina> disciplinas;

        public Func<Materia, ValidationResult> GravarRegistro { get; set; }

        public Materia Materia


        {
            get
            {
                return materia;
            }
            set
            {
                materia = value;
                txtNumero.Text = materia.Numero.ToString();
                cmbDisciplina.Text = "Selecione";
                txtMateria.Text = materia.Nome;



            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            materia.Disciplina.Nome = cmbDisciplina.Text;

            materia.Nome = txtMateria.Text;

            var resultadoValidacao = GravarRegistro(materia);

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }

        private void TelaCadastroDisciplinaForm_Load(object sender, EventArgs e)
        {
            TelaPrincipalForm.Instancia.AtualizarRodape("");
        }

        private void TelaCadastroDisciplinaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TelaPrincipalForm.Instancia.AtualizarRodape("");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void CarregarDisciplinasComboBox()
        {

            cmbDisciplina.Items.Clear();

            List<Disciplina> disc = repositorioDisciplina.SelecionarTodos();

            foreach (Disciplina d in disc)
            {
                cmbDisciplina.Items.Add(d.Nome);
            }
        }
    }
}
