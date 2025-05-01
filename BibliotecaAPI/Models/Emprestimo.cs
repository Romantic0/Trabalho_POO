using BibliotecaAPI.Models;
using System.Text.Json.Serialization;

public class Emprestimo
{
    public int Id { get; set; }
    public int LivroId { get; set; }
    
    public Livro? Livro { get; set; } 

    public string NomeUsuario { get; set; }
    [JsonIgnore]
    public DateTime DataEmprestimo { get; set; }
    [JsonIgnore]
    public DateTime DataDevolucao { get; set; }
}
