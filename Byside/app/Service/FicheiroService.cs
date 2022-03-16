using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Per;

namespace Service{
public class FicheiroService: IFicheiroService {

    IFicheiroPersistence pers = new FicheiroPersistence();
       
    public void criarFicheiro(string file, string localizacao){
         pers.cirarFicheiro(file, localizacao);
    }
    
    //metodo para calcular tamanho da pasta - polimorfismo
    // public void calcularTamanho()
    // {
    //     Tamanho = Conteudo.Length;
    // }

    // public string gerarLocalizacao(string nome_pasta, string localizacao_pasta)
    // {

    //     return localizacao_pasta + "/" + nome_pasta;
    // }
}
}