using gestaoTestesMariana.Dominio.ModuloQuestao;
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

namespace gestaoTestesMariana.WinFormsApp.ModuloQuestao
{
    public partial class TelaCadastroQuestaoForm : Form
    {
        public TelaCadastroQuestaoForm()
        {
            InitializeComponent();
        }



        private Questao questao;

        public Func<Questao, ValidationResult> GravarRegistro { get; set; }

        public Questao Questao
        {
            get
            {
                return questao;
            }
            set
            {
                questao = value;



            }
        }
    }
}
