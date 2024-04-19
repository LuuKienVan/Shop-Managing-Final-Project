using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM711.DAO.Pattern.Observer
{
    public abstract class Subject
    {
        protected List<Observer> observer = new List<Observer>();

        public void AddObserver(Observer observer)
        {
            this.observer.Add(observer);
        }

        public void RemoveObserver(Observer observer)
        {
            this.observer.Remove(observer);
        }

        public abstract void NotifyObserver(Subject subject);
    }
}
