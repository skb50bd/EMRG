using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Faculty : Person
    {
        public string Initial { get; set; }
        public string Designation { get; set; }
        public List<Section> Sections { get; set; }

        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        //public DateTime JoinDate => Meta.CreatedAt.Date;
        public DateTime JoinDate()
        {
            if(Meta.CreatedAt.Date != null)
            {
                return Meta.CreatedAt.Date;
            }
            else
            {
                return DateTime.Parse("06/01/1995");
            }
        }
    }
}