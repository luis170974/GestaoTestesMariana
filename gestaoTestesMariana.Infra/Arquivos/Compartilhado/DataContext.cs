using gestaoTestesMariana.Dominio.ModuloDisciplina;
using gestaoTestesMariana.Dominio.ModuloMateria;
using gestaoTestesMariana.Dominio.ModuloQuestao;
using gestaoTestesMariana.Dominio.ModuloTeste;
using gestaoTestesMariana.Infra.Arquivos;
using gestaoTestesMariana.Infra.Arquivos.Compartilhado.Serializadores;
using System;
using System.Collections.Generic;
using System.Linq;

namespace gestaoTestesMariana.Infra.Arquivos
{
    [Serializable]
    public class DataContext //Container
    {
        private readonly ISerializador serializador;

        public DataContext()
        {
            Testes = new List<Teste>();

            Disciplinas = new List<Disciplina>();

            Questoes = new List<Questao>();

            Materias = new List<Materia>();
        }

        public DataContext(ISerializador serializador) : this()
        {
            this.serializador = serializador;

            CarregarDados();
        }

        public List<Teste> Testes { get; set; }

        public List<Disciplina> Disciplinas { get; set; }

        public List<Questao> Questoes { get; set; }

        public List<Materia> Materias { get; set; }

        public void GravarDados()
        {
            serializador.GravarDadosEmArquivo(this);
        }

        private void CarregarDados()
        {
            var ctx = serializador.CarregarDadosDoArquivo();

            if (ctx.Testes.Any())
                this.Testes.AddRange(ctx.Testes);

            if (ctx.Disciplinas.Any())
                this.Disciplinas.AddRange(ctx.Disciplinas);

            if (ctx.Questoes.Any())
                this.Questoes.AddRange(ctx.Questoes);

            if (ctx.Materias.Any())
                this.Materias.AddRange(ctx.Materias);
        }
    }
}
