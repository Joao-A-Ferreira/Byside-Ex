namespace IModel
{
    public enum Tipos
    {
        txt,
        png,
        doc,
        mp4
    }
    public interface IFicheiro
    {
        string Nome { get; set; }
        string Localizacao { get; set; }
        Tipos Type { get; set; }
        string Permissoes { get; set; }
        string Conteudo { get; set; }

    }
}