using System.Text.Json.Serialization;

namespace BibliotecaAPI.Models
{
    public class Editora
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        
        public List<Livro> Livros { get; set; }
    }
}
