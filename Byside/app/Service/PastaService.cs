using IService;
using IPer;
using Per;
using System;
using System.Collections.Generic;
using Model;
namespace Service
{
    public class PastaService : IPastaService
    {
        IPastaPersistence ppp = new PastaPersistence();
        public void criarPasta(string nome, string localizacao)
        {
            if (nome == "")
            {
                Console.WriteLine("Pasta tem que ter nome");
            }
            else
            {
                Console.WriteLine("pretende criar past: " + localizacao + "/" + nome + " ?");
                string x = Console.ReadLine();
                if (x == "yes" || x == "Y" || x == "y" || x == "sim" || x == "SIM")
                {
                    ppp.criarPasta(nome, localizacao);
                }
                else
                {
                    Console.WriteLine("Processo terminado!");
                }
            }
        }

        public List<Pasta> listarPastas()
        {
            return ppp.listarPastas();
        }
    }
}