using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Admin
    {
        public Admin( string nom, string prénom, string email,String password)
        {
            Nom = nom;
            Prénom = prénom;
            Email = email;
            Password = password;
          
        }
      
        public string Nom { get; set; }
        public string Prénom { get; set; }
        public string Email { get; set; }
        public string Password { get;  set; }
    }
    
}
