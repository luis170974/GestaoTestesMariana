using gestaoTestesMariana.Dominio.ModuloQuestao;
using gestaoTestesMariana.WinFormsApp.Compartilhado;
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
    public partial class TabelaQuestoesControl : UserControl
    {
        public TabelaQuestoesControl()
        {
            InitializeComponent();
        }

        private DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Numero", HeaderText = "Número"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Pergunta", HeaderText = "Pergunta"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Materias", HeaderText = "Matéria"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Disciplinas", HeaderText = "Disciplina"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Alternativas", HeaderText = "Alternativas"},


            };

            return colunas;
        }

        public void AtualizarRegistros(List<Questao> questoes)
        {
            grid.Rows.Clear();

            foreach (Questao questao in questoes)
            {
                grid.Rows.Add(questao.Numero, questao.Pergunta, questao.Materia, questao.Disciplina, questao.Alternativas);
            }
        }

        internal object ObtemNumeroQuestaoSelecionada()
        {
            return grid.SelecionarNumero<int>();
        }
    }
}
