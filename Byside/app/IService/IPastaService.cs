
using System;
using System.Collections.Generic;
using Model;
namespace IService
{

    public interface IPastaService
    {

        public void criarPasta(string nome, string localizacao){}
        public List<Pasta> listarPastas();
        
    }
}