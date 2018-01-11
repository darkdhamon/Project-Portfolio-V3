using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PortfolioModel.Entities;

namespace Project_Portfolio.Models
{
    public class ProjectListViewModel
    {
        public List<Project> Projects { get; set; }
        public int NumOfRowsOfFour => Projects.Count / 4;
    }
}