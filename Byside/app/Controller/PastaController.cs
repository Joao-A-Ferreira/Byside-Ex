using IController;
using IService;
using Service;
using System.Collections.Generic;
using Model;
namespace Controller
{
    public class PastaController : IPastaController
    {
        static IPastaService ip = new PastaService();
        //exemplo de uso de polimorfismo pasta sem localização vai para a root
        public void criarPasta(string nome)
        {
            ip.criarPasta(nome, "/root");
        }

        public void criarPasta(string nome, string localizacao)
        {
            List<string> lista = new List<string>(localizacao.Split('/'));
            if (lista.Count < 1)
            {
                criarPasta(nome);
            }

            List<string> x = new List<string>();
            lista.Reverse();
            criarPasta(lista[0], lista, x);
            //remove  lista[0].
        }


        //criar pastas em sequencia    
        //se a pasta tiver mais que um elemento guardar o ultimo e remover
        // depois guardar o seguinte adicionando o que foi removido a localizacao
        // l - lista atual   nova - lista dos removidos
        public void criarPasta(string nome, List<string> l, List<string> nova)
        {
            if (l.Count > 1)
            {

                string dir = "";

                foreach (string item in l)
                {
                    dir = dir + "/" + item;
                }
                l.Remove(nome);
                nova.Add(nome);


                ip.criarPasta(nome, dir);
            }
            criarPasta(l[0], l, nova);
        }

        public List<Pasta> listarPastas()
        {
            return ip.listarPastas();
        }

    }
}
