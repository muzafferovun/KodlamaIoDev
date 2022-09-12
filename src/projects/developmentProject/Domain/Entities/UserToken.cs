using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserToken:Entity
    {
        public int UserId { get; set; } 
        public string Name { get; set; }    
        public string Token { get; set; }   
        public string Device { get; set; }  
        public bool IsActive { get; set; }  
        public DateTime Created { get; set; }   
        public DateTime Updated { get; set; }   
        public DateTime Expiration { get; set; }  
        public virtual User? User { get; set; }

        public UserToken(int id,int userId, string name, string device, bool ısActive, DateTime created, DateTime updated, DateTime expiration)
        {
            Id = id;    
            UserId = userId;
            Name = name;
            Device = device;
            IsActive = ısActive;
            Created = created;
            Updated = updated;
            Expiration = expiration;
          
        }

        public UserToken()
        {
        }
    }
}
