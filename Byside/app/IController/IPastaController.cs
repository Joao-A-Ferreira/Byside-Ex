
using System;
using System.Collections.Generic;
using Model;

namespace IController{

public interface IPastaController{
     public void criarPasta(string nome, string localizacao){}
     public void criarPasta(string nome){}
     private void criarPasta(string nome, List<string> localizacao, List<string> diretorio){}
     public List<Pasta> listarPastas();
}    
}