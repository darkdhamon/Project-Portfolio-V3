using System;
using System.Linq;
using System.Web.Mvc;
using PortfolioModel.Abstract;
using PortfolioModel.Entities;
using Project_Portfolio.Models;

namespace Project_Portfolio.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectController(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        // GET: Project
        public ActionResult Index(int page = 1, int pageSize = 12)
        {
            var viewModel = new ProjectListViewModel
            {
                Projects = _projectRepository.GetMany().OrderBy(p=>p.Updated).Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                CurrentPage = page,
                PageSize = pageSize,
                NumPages = (int) Math.Round(_projectRepository.GetMany().Count()*1.0/pageSize,0,MidpointRounding.AwayFromZero)
            };
            return View(viewModel);
        }

        public ActionResult FeaturedProjects()
        {
            var viewModel = new ProjectListViewModel
            {
                Projects = _projectRepository.GetMany().Where(p => p.Featured).ToList()
            };


            return PartialView(viewModel);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id = 0)
        {
            var project = _projectRepository.GetEntity(id) ?? new Project();
            return View(project);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Edit(Project project = null)
        {
            if (!ModelState.IsValid) return View(project);
            ModelState.Clear();
            if (project != null) _projectRepository.AddOrUpdate(project);
            return View(project);
        }
        
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            _projectRepository.Delete(id);
            return RedirectToAction("Index", "Project");
        }
    }
}