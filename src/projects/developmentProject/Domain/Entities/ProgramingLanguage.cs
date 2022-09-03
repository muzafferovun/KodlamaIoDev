using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProgramingLanguage:Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public ProgramingLanguage(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public ProgramingLanguage()
        {

        }
    }
}
