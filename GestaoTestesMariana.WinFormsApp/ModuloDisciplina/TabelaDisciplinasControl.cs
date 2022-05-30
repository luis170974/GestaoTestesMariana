using gestaoTestesMariana.Dominio.ModuloDisciplina;
using gestaoTestesMariana.WinFormsApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace gestaoTestesMariana.WinFormsApp.ModuloDisciplina
{
    public partial class TabelaDisciplinasControl : UserControl
    {
        public TabelaDisciplinasControl()
        {
            InitializeComponent();     

            grid.ConfigurarGridSomenteLeitura();
            grid.ConfigurarGridZebrado();
            grid.Columns.AddRange(ObterColunas());
        }

        private DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Numero", HeaderText = "Número"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome da Disciplina"},

                
            };

            return colunas;
        }

        public void AtualizarRegistros(List<Disciplina> disciplinas)
        {

            grid.Rows.Clear();

            foreach (Disciplina disciplina in disciplinas)
            {
                grid.Rows.Add(disciplina.Numero, disciplina.Nome);
            }


        }

        internal object ObtemNumeroDisciplinaSelecionada()
        {
            return grid.SelecionarNumero<int>();
        }
    }
}
