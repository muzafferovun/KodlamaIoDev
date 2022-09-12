using Core.Persistence.Repositories;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User :Entity
    {
        public string UserName { get; set; }    
        public string Password { get; set; }
        public string Name;
        public string Surname;
        public string Email;    
        public string PhoneNumber;
        public bool IsEmailConfirmed { get; set; }
        public bool IsPhoneConfirmed { get; set; }  
        public bool IsActive { get; set; }  
        public string UserImage { get; set; }    
        public string GitAccount { get; set; } 
        public int UserTypeId { get; set; } 
        public virtual UserType UserType { get; set; }
        public virtual ICollection<UserToken> Tokens { get; set; }

        public User(int id,string userName, string password, string name, string surname, string email, string phoneNumber, bool ısEmailConfirmed, bool ısPhoneConfirmed, bool ısActive, string userImage, string gitAccount, int userTypeId)
        {
            Id = id;
            UserName = userName;
            Password = password;
            Name = name;
            Surname = surname;
            Email = email;
            PhoneNumber = phoneNumber;
            IsEmailConfirmed = ısEmailConfirmed;
            IsPhoneConfirmed = ısPhoneConfirmed;
            IsActive = ısActive;
            UserImage = userImage;
            GitAccount = gitAccount;
            UserTypeId = userTypeId;
        }

        public User()
        {
        }
    }
}
