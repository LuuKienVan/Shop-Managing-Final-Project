using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PM711.DAO.Pattern.Observer
{
    public interface Observer
    {
        void Notify(Subject subject);
    }
}
