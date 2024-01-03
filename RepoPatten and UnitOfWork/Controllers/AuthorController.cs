using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepoPatten_and_UnitOfWork.Model;
using RepoPatten_and_UnitOfWork.repo.Interfaces;
using RepoPatten_and_UnitOfWork.Unit_Of_Work;

namespace RepoPatten_and_UnitOfWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IUnitOfWork unitofwork;

        public AuthorController(IUnitOfWork unitofwork)
        {
            this.unitofwork = unitofwork;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
           return Ok(unitofwork.Auhtors.GetAll());
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            return Ok(unitofwork.Auhtors.GetById(id));
        }

        [HttpGet("AllwithInclude")]
        public IActionResult GetAllWithInclude()
        {
            return Ok(unitofwork.Auhtors.GetAllWithInclude());
        }

        [HttpGet("ShowByorder")]
        public IActionResult ShowByOrder()
        {
            return Ok(unitofwork.Auhtors.Order(a => a.Id));
        }


       
    }
}
