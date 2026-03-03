using RestWithAspNet.Interfaces;

namespace RestWithAspNet.Models
{
    public class SuperHeroi(string nome, DateTime dataNascimento, int nivelKriptonita) : Pessoa(nome, dataNascimento), ISuperHeroi 
    {
        public required int NivelKriptonita { get; init; } = nivelKriptonita;

        public string Voar()
        {
            if (NivelKriptonita < 2)
                return "Voando...";
            else
                return "Não posso voar, estou fraco por causa da kriptonita!";
        }
    }
}
