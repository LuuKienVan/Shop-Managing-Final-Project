namespace Pattern.Decorator
{
    public class DefaultHoaDon : HoaDon
    {
        public DefaultHoaDon(int tongTien)
        {
            base.Cost = tongTien;
        }


        public override double getThanhTien()
        {
            return Cost;
        }
    }
}
