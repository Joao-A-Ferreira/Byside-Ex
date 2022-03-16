using System;
using IModel;

namespace Model
{
    public class Pasta : IPasta
    {
        private double DEFAULT_TAMANHO = 0.0;
        //construtor vazio de Pasta
        public Pasta()
        {
        }
        //construtor, pasta sem ficheiros
        public Pasta(string nome, string localizacao)
        {
            Nome = nome;
            Localizacao = localizacao;
            Tamanho = DEFAULT_TAMANHO;
        }
        //construtor de Pasta
        public Pasta(string nome, string localizacao, double tamanho)
        {
            Nome = nome;
            Localizacao = localizacao;
            Tamanho = tamanho;
        }

        public string Nome { get; set; }

        public string Localizacao { get; set; }

        public double Tamanho { get; set; }

        //metodo para calcular tamanho da pasta - polimorfismo
        // public void calcularTamanho(Ficheiro[] x)
        // {
        //     foreach (Ficheiro y in x)
        //     {

        //         this.Tamanho += y.Tamanho;
        //     }
        // }

        // public void mudarNome(string novoNome)
        // {
        //     this.Nome = novoNome;
        // }


    }

}