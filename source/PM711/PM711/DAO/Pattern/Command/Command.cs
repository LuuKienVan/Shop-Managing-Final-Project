using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PM711;
using DAO.Pattern.Proxy.FormProxy;
using PM711.DAO.Pattern.Template.FormLoadingTemplate;

namespace Pattern.Command
{
    public abstract class Command
    {
        public abstract void execute();
    }

    public class ThanhToanCommand : Command
    {

        public ThanhToanCommand()
        {

        }
        public override void execute()
        {
            FormLoading thanhtoan = new ThanhToanForm();
            thanhtoan.loadForm();
        }
    }

    public class DoanhThuCommand : Command
    {

        public DoanhThuCommand() 
        {

        }
        public override void execute()
        {
            IForm doanhthu = new DoanhThuPageProxy(DangNhap.role);
            doanhthu.loadForm();
        }
    }

    public class KhoCommand : Command
    {

        public KhoCommand()
        {

        }

        public override void execute()
        {
            FormLoading kho = new KhoForm();
            kho.loadForm();
        }
    }

    public class NhaCungCapCommand : Command
    {


        public NhaCungCapCommand()
        {

        }
        public override void execute()
        {

            FormLoading nhacungcap = new NhaCungCapForm();
            nhacungcap.loadForm();
        }
    }
    public class GiaoHangCommand : Command
    {

        public GiaoHangCommand()
        {

        }
        public override void execute()
        {
            FormLoading giaohang = new QuanLyDonOnlineForm();
            giaohang.loadForm();
        }
    }
}
