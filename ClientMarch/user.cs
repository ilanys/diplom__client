using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientMarch
{
   public class user
    {
        private string login;
        private string token;
        private string name;
        private string email;
        private string errors="";
        private string types = "";
        public string  location = "";
        private string offical__name = "";
        private string Activate = "";

        public void post__user(string logins, string tokens, string names, string emails, string type)
        {
            login = logins;
            token = tokens;
            name = names.Split(' ')[0];
            email = emails;
            types = type;
        }
        public string get__token()
        {
            return token;
        }
        public void error( string eror)
        {
            errors = eror;
            post__user("", "", "", "","");
            return;
        }
        public string get__Error()
        {
            return errors;
        }
        public string get__type()
        {
            return types;
        
        }
        public string get__name()
        {
            return name;
        }
        public bool Service__in(string locations, string offical__names, string Activates)
        {
            location = locations;
            offical__name = offical__names;
            Activate = Activates;
            return true;
        }
    }
}
