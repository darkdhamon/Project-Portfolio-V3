using System.Collections.Generic;
using PortfolioModel.Entities;

namespace Project_Portfolio.Models
{
    public class ProjectListViewModel
    {
        public List<Project> Projects { get; set; }
        public int NumOfRowsOfFour => Projects.Count / 4;
        public int CurrentPage { get; set; }
        public int NumPages { get; set; }
        public int PageSize { get; set; }
    }
}