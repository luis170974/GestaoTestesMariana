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
        public TelaCadastroMateriaForm()
        {
            InitializeComponent();
        }

        private Materia materia;

        private Disciplina disciplina;

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
                cmbDisciplina.Text = disciplina.Nome;
                txtMateria.Text = materia.Nome;



            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            disciplina.Nome = cmbDisciplina.Text;
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
    }
}
