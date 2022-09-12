using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserType:Entity
    {
        public string Name { get; set; }
        public virtual ICollection<User> Users  { get; set; }
        public UserType(int id,string name)
        {
            Id = id;    
            Name = name;
        }

        public UserType()
        {
        }

     }

}
