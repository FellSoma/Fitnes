using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnes
{
    class User
    {
        [Key]
        public int id { get; set; }

        private string Login, email, pass, name, age, abautme; 

        public string login
        {
            get { return Login; }
            set { Login = value; }
        }
        public string Pass
        {
            get { return pass; }
            set { pass = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
       
        public User() { }

        public User(string login,string email,string pass)
        {
            this.Login = login;
            this.pass = pass;
            this.email = email;
        }
    
    }
}
