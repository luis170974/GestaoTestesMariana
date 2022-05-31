using gestaoTestesMariana.Dominio.ModuloDisciplina;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FluentValidation.Results;
using GestaoTestesMariana.WinFormsApp;

namespace gestaoTestesMariana.WinFormsApp.ModuloDisciplina
{
    public partial class TelaCadastroDisciplinaForm : Form
    {
        public TelaCadastroDisciplinaForm()
        {
            InitializeComponent();
        }

        private Disciplina disciplina;

        public Func<Disciplina, ValidationResult> GravarRegistro { get; set; }

        public Disciplina Disciplina
        {
            get { return disciplina; }
            set
            {

                disciplina = value;
                txtNumero.Text = disciplina.Numero.ToString();
                txtDisciplina.Text = disciplina.Nome;



            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            disciplina.Nome = txtDisciplina.Text;

            var resultadoValidacao = GravarRegistro(disciplina);

            if(resultadoValidacao.IsValid == false)
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
    }
}
