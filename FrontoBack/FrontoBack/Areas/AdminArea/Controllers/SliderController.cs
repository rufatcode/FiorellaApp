using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrontoBack.Areas.AdminArea.Helper;
using FrontoBack.Areas.AdminArea.ViewModel;
using FrontoBack.Areas.AdminArea.ViewModel.SliderVM;
using FrontoBack.DAL;
using FrontoBack.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FrontoBack.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class SliderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        // GET: /<controller>/
        public SliderController(AppDbContext context,IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {

            return View(_context.Sliders.ToList()) ;
        }
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(CreateSliderVM createSliderVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (!createSliderVM.Image.IsImage())
            {
                ModelState.AddModelError("Image", "Only Image");
                return View();
            }
            else if (!createSliderVM.Image.IsLenghSuit(1000))
            {
                ModelState.AddModelError("Image", "max size must be 1kb");
                return View();
            }
            string fileName = Guid.NewGuid().ToString() + createSliderVM.Image.FileName;
            string path = Path.Combine(_webHostEnvironment.WebRootPath, "img", fileName);
            using(FileStream stream=new FileStream(path, FileMode.Create))
            {
                createSliderVM.Image.CopyTo(stream);
            }
            _context.Add(new Slider { ImgSrc = fileName });
            _context.SaveChanges();
            return RedirectToAction("Index","Slider");
        }
        public IActionResult Delete(int? id)
        {
            if (id==null)
            {
                return BadRequest();
            }
            Slider slider = _context.Sliders.FirstOrDefault(s => s.Id == id);
             if (slider==null)
            {
                return NotFound();
            }
            string path = Path.Combine(_webHostEnvironment.WebRootPath, "img", slider.ImgSrc);
           
            System.IO.File.Delete(path);
            
            _context.Sliders.Remove(slider);
            _context.SaveChanges();
            
            return RedirectToAction("Index","Slider");
        }
        public IActionResult Update(int? id)
        {
            if (id==null)
            {
                return BadRequest("Slider not found");
            }
            Slider slider = _context.Sliders.FirstOrDefault(s => s.Id == id);
            if (slider==null)
            {
                return NotFound("slider not exist");
            }
            ViewBag.Image = slider.ImgSrc;
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Update(int id,UpdateSliderVM updateSliderVM)
        {
            ViewBag.Image = _context.Sliders.FirstOrDefault(s=>s.Id==id).ImgSrc;
            if (!ModelState.IsValid)
            {
                return View();
            }
            else if (!updateSliderVM.Image.IsImage())
            {
                ModelState.AddModelError("Image", "Only Image");
                return View();
            }
            else if (!updateSliderVM.Image.IsLenghSuit(1000))
            {
                ModelState.AddModelError("Image", "size must be smaller than 1kb");
                return View();
            }
            string fileName = Guid.NewGuid().ToString() + updateSliderVM.Image.FileName;
            string path = Path.Combine(_webHostEnvironment.WebRootPath, "img",fileName);
            using(FileStream stream=new FileStream(path, FileMode.Create)){
                updateSliderVM.Image.CopyTo(stream);
            }
            Slider slider = _context.Sliders.FirstOrDefault(s => s.Id == id);
            System.IO.File.Delete(Path.Combine(_webHostEnvironment.WebRootPath, "img", slider.ImgSrc));
            slider.ImgSrc = fileName;
            _context.SaveChanges();
            return RedirectToAction("Index","Slider");
        }
    }
}

