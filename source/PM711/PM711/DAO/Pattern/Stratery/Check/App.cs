using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM711.DAO.Pattern.Stratery.Check
{
    public class App
    {
        private CheckStratery checkStratery;

        public void setCheck(CheckStratery checkStratery)
        {
            this.checkStratery = checkStratery;
        }

        public bool getCheck(string check)
        {
            return checkStratery.check(check);
        }
    }
}
