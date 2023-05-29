using MasterFinalProjectAdmin.Interface;
using MasterFinalProjectAdmin.Models;
using Microsoft.AspNetCore.Mvc;

namespace MasterFinalProjectAdmin.Controllers
{
    public class RoomController : Controller
    {
        private IRoomRepository<Room> _repository;
        public RoomController(IRoomRepository<Room> repository)
        {
            _repository = repository;
        }
        public async Task<IActionResult> Index()
        {
            List<Room> allClass = await _repository.GetAll();
            return View(allClass);
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAll()
        {
            var subjects = await _repository.GetAll();
            return Ok(subjects);
        }
        [HttpGet]
        [Route("[action]/{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var stude = await _repository.GetById(id);
            if (stude != null)
            {
                return Ok(stude);
            }
            return NotFound();
        }
       
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Create(Room subject)
        {
            var clas = await _repository.Create(subject);
            if (clas != null)
            {
                return RedirectToAction("Index");
            }
            return Conflict();
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Update(int id)
        {
            var clas = await _repository.GetById(id);
            return View(clas);
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Update(Room subject)
        {
            if (await _repository.Update(subject) != null)
            {
                return RedirectToAction("Index");

            }
            return NotFound();
        }
        [Route("[action]")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _repository.GetById(id) != null)
            {
                await _repository.Delete(id);
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}
