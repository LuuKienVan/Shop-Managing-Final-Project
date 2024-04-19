using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM711.DAO.Pattern.Stratery.Check
{
    public class CheckNumber : CheckStratery
    {
        public bool check(string check)
        {
            if (int.Parse(check) > 0)
                return true;
            return false;
        }
    }
}
