using gestaoTestesMariana.Dominio.ModuloTeste;
using gestaoTestesMariana.WinFormsApp.Compartilhado;
using System.Collections.Generic;
using System.Windows.Forms;

namespace gestaoTestesMariana.WinFormsApp.ModuloTeste
{
    public partial class TabelaTestesControl : UserControl
    {
        public TabelaTestesControl()
        {
            InitializeComponent();
        }

        private DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Numero", HeaderText = "Número"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Titulo", HeaderText = "Titulo"},


                new DataGridViewTextBoxColumn { DataPropertyName = "Disciplinas", HeaderText = "Disciplina"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Materias", HeaderText = "Matéria"},

                new DataGridViewTextBoxColumn { DataPropertyName = "DataTeste", HeaderText = "Data"},

                new DataGridViewTextBoxColumn { DataPropertyName = "QtdQuestoes", HeaderText = "Quantidade de Questões"},


            };

            return colunas;
        }

        public void AtualizarRegistros(List<Teste> testes)
        {
            grid.Rows.Clear();

            foreach (Teste teste in testes)
            {
                grid.Rows.Add(teste.Numero, teste.Titulo, teste.Disciplinas, teste.Materias, teste.DataTeste,teste.QtdQuestoes);
            }
        }

        public object ObtemNumeroTesteSelecionado()
        {
            return grid.SelecionarNumero<int>();
        }


    
    }
}

