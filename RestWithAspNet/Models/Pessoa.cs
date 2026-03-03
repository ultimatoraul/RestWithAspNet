namespace RestWithAspNet.Models
{
    public class Pessoa(string nome, DateTime dataNascimento)
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Nome { get; init; } = nome;
        public DateTime? DataNascimento { get; init; } = dataNascimento;
    }
}
