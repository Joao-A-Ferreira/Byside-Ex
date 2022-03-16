
using System;
using System.Collections.Generic;
using System.Linq;
using Model;
using Microsoft.Data.Sqlite;
using Controller;
using IController;


namespace Byside
{
    class Program
    {
        static string connectionString = @"Data Source=Byside.db";
        //Controller.IFicheiroController cont = new Controller.IFicheiroController();
        static IFicheiroController controllersf = new FicheiroController();

        static IPastaController controllers_p = new PastaController();

        static void Main(string[] args)
        {

            using (var connection = new SqliteConnection(connectionString))
            {
                //open Byside.db com sqlite viwer
                connection.Open();
                var tableCmd = connection.CreateCommand();

                tableCmd.CommandText =
                //DROP TABLE PASTA;
                @"CREATE TABLE IF NOT EXISTS PASTA (
                        nome  				varchar(20),
                        localizacao			varchar(100),
                        tamanho      	    double(7),
                        data_criacao		timestamp,
                        Nome_pasta			varchar(20),
                        Localizacao_pasta	varchar(100),
                constraint pk_pasta primary key (nome, localizacao),
                constraint fk_pasta_pai foreign key (Nome_pasta, Localizacao_pasta) references PASTA(nome, localizacao)
                );
                
                 CREATE TABLE IF NOT EXISTS FICHEIRO (
                        nome			    varchar(20),
                        Nome_pasta		    varchar(20),
                        Localizacao_pasta	varchar(100),
                        tipo			    varchar(3),
                        tamanho		        double(7),
                        data_criacao		timestamp,
                        data_modificacao	timestamp,
                        data_acedido 		timestamp,

                constraint pk_ficheiro primary key (nome, Nome_pasta, Localizacao_pasta),
                constraint fk_ficheiro_localizacao foreign key (Nome_pasta, Localizacao_pasta) references PASTA(nome, localizacao)
                )";


                tableCmd.ExecuteNonQuery();

                connection.Close();

            }

            GetUserInput();

        }

        static void GetUserInput()
        {
            bool closeApp = false;
            //gerar pastas atuais
            List<Pasta> pastas = controllers_p.listarPastas();


            while (closeApp == false)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1) Criar Pasta");
                Console.WriteLine("2) Listar, Gerir Pastas");
                Console.WriteLine("3) Copiar Pasta para nova localizacao");
                Console.WriteLine("4) Exit");
                Console.Write("\r\nSelect an option: ");

                string commandInput = Console.ReadLine();

                switch (commandInput)
                {
                    case "1":

                        Console.WriteLine("Nome do Fichiro");
                        string user_input_criar = Console.ReadLine();
                        Console.WriteLine("Indique localizacao do ficheiro");
                        string input_localizacao = Console.ReadLine();

                        if (input_localizacao == null || input_localizacao == "" || input_localizacao.Length >0)
                        {
                            Console.WriteLine("Diretorio /root");
                            controllers_p.criarPasta(user_input_criar);
                        }
                        else
                        {//separar localizacao por /  e criar pastas para essas localizacoes

                            controllers_p.criarPasta(user_input_criar, input_localizacao);

                            // string[] words = input_localizacao.Split('/');
                            // //reverter o array de modo a intruduzir primeiro a ultima pasta 
                            // //( nome:d localizacao:a/b/c c/b/a; primeiro quero guardar a pasta c com localizacao a/b)
                            // var reverse = words.Reverse();
                            // //recursividade
                            // foreach (var word in reverse)
                            // {  foreach(var )
                            //     controllers_p.criarPasta(word, ) 

                            //    controllers_p.criarPasta(word, words);
                            //    System.Console.WriteLine($"<{word}>");
                            // }
                        }

                        break;
                    case "2":
                        Console.WriteLine("Pastas Disponiveis");
                        int cont = 0;
                        List<Pasta> pastas_update = controllers_p.listarPastas();

                        foreach (var item in pastas_update)
                        {
                            Console.WriteLine("Pasta[" + cont + "]" + item.Nome + "\n" + "localização:" + item.Localizacao);
                            cont++;
                        }

                        break;
                    case "3":

                        Console.WriteLine("Selecionar Pasta, escreva o seu nome ou numero");
                        var user_input_copiar = Console.ReadLine();
                        Console.WriteLine("Selecionar localizacao");
                        var user_input_localizacao = Console.ReadLine();

                        if (user_input_copiar.All(char.IsDigit))
                        {
                            var x = pastas[Int32.Parse(user_input_copiar)];
                            if (user_input_localizacao != x.Localizacao)
                            {
                                controllers_p.criarPasta(x.Nome, user_input_localizacao);
                                
                            }
                            else { Console.WriteLine("Nome da Localizacao não pode ser o mesmo"); }
                        }
                        else
                        {
                            foreach (var item in pastas)
                            {
                                if (item.Nome == user_input_copiar)
                                {
                                    if (user_input_localizacao != item.Localizacao)
                                    {
                                        controllers_p.criarPasta(user_input_copiar, user_input_localizacao);
                                        
                                    }
                                    else { Console.WriteLine("Nome da Localizacao não pode ser o mesmo"); }
                                }
                            }
                        }
                        break;
                    case "4":

                        Console.WriteLine("Aplicação fechada.");
                        closeApp = true;

                        break;
                    default:

                        break;
                }
            }

        }
    }
}