using System.ComponentModel.DataAnnotations.Schema;

namespace RepoPatten_and_UnitOfWork.Model
{
    public class Book
    {
        public int Id { get; set; } 
        public string Title { get; set; }

        [ForeignKey("Author")]
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
