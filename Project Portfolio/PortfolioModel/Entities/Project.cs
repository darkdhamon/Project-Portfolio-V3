using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PortfolioModel.Entities
{
    public class Project
    {
        private List<Technology> _technologies;
        private List<Profile> _collaborators;
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string DemoUrl { get; set; }
        public string SourceUrl { get; set; }

        //public List<Technology> Technologies
        //{
        //    get => _technologies??(_technologies=new List<Technology>());
        //    set => _technologies = value;
        //}

        //public List<Profile> Collaborators
        //{
        //    get => _collaborators??(_collaborators=new List<Profile>());
        //    set => _collaborators = value;
        //}

        public bool Featured { get; set; }
        public DateTime Updated { get; set; }
    }
    
    public class Technology
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Project> Projects { get; set; }
    }
}
