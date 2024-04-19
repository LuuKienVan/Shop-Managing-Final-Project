using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM711.DAO.Pattern.Stratery.Check
{
    public class CheckPhone : CheckStratery
    {
        public bool check(string check)
        {
            if (check.Length == 10)
                return true;
            return false;
        }
    }
}
