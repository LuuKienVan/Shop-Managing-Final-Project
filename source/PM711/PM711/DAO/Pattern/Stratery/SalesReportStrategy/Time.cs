using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Stratery
{
    public class Time
    {
        private int thang;
        private int nam;

        public Time(int thang, int nam)
        {
            this.thang = thang;
            this.nam = nam;
        }

        public Time(int nam)
        {
            this.nam = nam;
        }

        public int Thang { get => thang; set => thang = value; }
        public int Nam { get => nam; set => nam = value; }
    }
}
