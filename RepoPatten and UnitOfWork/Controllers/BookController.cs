using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepoPatten_and_UnitOfWork.Const;
using RepoPatten_and_UnitOfWork.Model;
using RepoPatten_and_UnitOfWork.repo.Interfaces;
using RepoPatten_and_UnitOfWork.Unit_Of_Work;

namespace RepoPatten_and_UnitOfWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IUnitOfWork unitofwork;
        public BookController( IUnitOfWork unitofwork )
        {
            this.unitofwork = unitofwork;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(unitofwork.books.GetAll());
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            return Ok(unitofwork.books.GetById(id));
        }


        [HttpGet("WithIclude")]
        public IActionResult GetInclude(int id)
        {
            return Ok(unitofwork.books.GetOneWithInclude( b=>b.Id == id, new[] { "Author" } ));
        }

        [HttpGet("AllwithInclude")]
        public IActionResult GetAllWithInclude()
        {
            return Ok(unitofwork.books.GetAllWithInclude(new[] { "Author" }));
        }

        [HttpGet("ShowByorder")]
        public IActionResult ShowByOrder()
        {
            return Ok(unitofwork.books.Order(a => a.Id , OrderDir.Assending , new string[] {"Author"} ));
        }

        [HttpPost("Add")]
        public IActionResult Add( )
        {
            var book = unitofwork.books.Add(new Book { AuthorId=1 , Title="football"});
            unitofwork.complete();
            return Ok(book); 
        }

    }
}
