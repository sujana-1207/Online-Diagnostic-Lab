using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthService.Repository
{
    public class LoginRepository : ILogin
    {
        private DiagnosticLabContext _cxt;
        
        public LoginRepository()
        {
            _cxt = new DiagnosticLabContext();
        }
        public LoginRepository(DiagnosticLabContext cxt)
        {
            _cxt = cxt;
        }
        public User GetUser(string uname)
        {
            User u = _cxt.Users.Where(s => s.Username == uname).FirstOrDefault();            
            return u;
        }
    }
}
