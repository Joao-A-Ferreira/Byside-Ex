using System;
using IModel;

//Herança Ficheiro herda os atributos (nome, localizacao, tamanho) de Pasta
namespace Model
{
    public class Ficheiro : Pasta, IFicheiro
    {
        private double DEFAULT_TAMANHO = 0.0;


        public Tipos Type { get; set; }
        public string Permissoes { get; set; }
        public string Conteudo { get; set; }
        //construtor vazio de Ficheiro
        public Ficheiro() { }

        //ficheiro sem conteudo, todas as permissoes, txt
        public Ficheiro(string nome, string localizacao) : base(nome, localizacao)
        {
            Nome = nome;
            Localizacao = localizacao;
            Type = Tipos.txt;
            Permissoes = "R, W, X, RW, RX";
            Tamanho = DEFAULT_TAMANHO;
        }

        //construtor de Ficheiro
        public Ficheiro(string nome, string localizacao, string tipo, string permissoes, double tamanho, string conteudo) : base(nome, localizacao, tamanho)
        {
            Nome = nome;
            Localizacao = localizacao;
            Type = (Tipos)Enum.Parse(typeof(Tipos), tipo);
            Permissoes = permissoes;
            Tamanho = tamanho;
            Conteudo = conteudo;
        }

    }
}