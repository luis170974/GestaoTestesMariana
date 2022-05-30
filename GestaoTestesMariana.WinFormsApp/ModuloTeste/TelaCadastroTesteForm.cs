using gestaoTestesMariana.Dominio.ModuloTeste;
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

namespace gestaoTestesMariana.WinFormsApp.ModuloTeste
{
    public partial class TelaCadastroTesteForm : Form
    {
        public TelaCadastroTesteForm()
        {
            InitializeComponent();
        }

        private Teste teste;

        public Func<Teste, ValidationResult> GravarRegistro { get; set; }

        public Teste Teste
        {
            get
            {
                return teste;
            }
            set
            {
                teste = value;



            }
        }
    }
}
