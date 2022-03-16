using Model;
using System;
using System.Collections.Generic;
namespace IPer
{
    public interface IPastaPersistence
    {
        public void criarPasta(string nome, string localizacao);
        public List<Pasta> listarPastas();
    }
}