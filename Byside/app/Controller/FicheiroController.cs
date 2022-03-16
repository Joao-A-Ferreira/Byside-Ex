using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using IController;
using Service;

namespace Controller{
public class FicheiroController: IFicheiroController{
   static IFicheiroService serv = new FicheiroService();
    // public void start(){

    // }
    private static void InsertFicheiro(string nome, string localizacao){
         serv.criarFicheiro(nome, localizacao) ;
    }
}
}
