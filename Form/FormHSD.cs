using QLBH_App.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBH_App
{
    public partial class FormHSD : Form
    {
        QLBanHangDBEntities db = new QLBanHangDBEntities();
        public FormHSD()
        {
            InitializeComponent();
        }

        private void FormHSD_Load(object sender, EventArgs e)
        {
            var result = (from c in db.SanPhams
                         join b in db.LoaiHangs
                         on c.LoaiSP equals b.MaLoai
                         orderby c.MaSP ascending
                         select
                         new
                         {
                             MaSP = c.MaSP,
                             TenSP = c.TenSP,
                             LoaiHang = b.TenLoai,
                             GiaNhap = c.GiaNhap,
                             GiaBan = c.GiaBan,
                             HSD = c.HSD,
                             SoLuong = c.SoLuong
                         }).ToList();
            var lst = result.Where(item => (DateTime.Parse(item.HSD.ToString()) - DateTime.Now).Days <= 30).ToList();
            dgvHSD.DataSource = lst;
            dgvHSD.Columns[1].Width = 300;

            dgvHSD.Columns[0].HeaderText = "Mã SP";
            dgvHSD.Columns[1].HeaderText = "Tên SP";
            dgvHSD.Columns[2].HeaderText = "Loại hàng";
            dgvHSD.Columns[3].HeaderText = "Giá nhập";
            dgvHSD.Columns[4].HeaderText = "Giá bán";
            dgvHSD.Columns[6].HeaderText = "Số lượng";

            for (int i = 1; i <= 3; i++)
            {
                cboHSD.Items.Add(i + " tháng");
            }
            cboHSD.SelectedIndex = 0;
        }


        private void cboHSD_SelectedValueChanged(object sender, EventArgs e)
        {
            /*DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            DataTable dt3 = new DataTable();*/
            DateTime now = DateTime.Now;
            var hsd = (from c in db.SanPhams
                      join b in db.LoaiHangs
                      on c.LoaiSP equals b.MaLoai
                      select
                      new
                      {
                          MaSP = c.MaSP,
                          TenSP = c.TenSP,
                          LoaiHang = b.TenLoai,
                          GiaNhap = c.GiaNhap,
                          GiaBan = c.GiaBan,
                          HSD = c.HSD,
                          SoLuong = c.SoLuong
                      }).ToList();

            var dt1 = hsd.Where(item => (DateTime.Parse(item.HSD.ToString()) - now).Days <= 30).ToList();
            var dt2 = hsd.Where(item => (DateTime.Parse(item.HSD.ToString()) - now).Days > 30 && (DateTime.Parse(item.HSD.ToString()) - now).Days <= 60).ToList();
            var dt3 = hsd.Where(item => (DateTime.Parse(item.HSD.ToString()) - now).Days > 60 && (DateTime.Parse(item.HSD.ToString()) - now).Days <= 90).ToList();


            /*for (int i = 0; i < hsd.Count(); i++)
            {
                TimeSpan time = DateTime.Parse(hsd[i].HSD.ToString()) - now;
                int exp = time.Days;
                if(exp < 30)
                {
                    dt1.Rows.Add(hsd[i]);
                }
                if(exp >= 30 && exp < 60)
                {
                    dt2.Rows.Add(hsd[i]);
                }
                if(exp >= 60 && exp < 90)
                {
                    dt3.Rows.Add(hsd[i]);
                }
            }*/
            switch (cboHSD.SelectedIndex)
            {
                case 0: dgvHSD.DataSource = dt1;
                    break;
                case 1: dgvHSD.DataSource = dt2;
                    break;
                case 2: dgvHSD.DataSource = dt3;
                    break;
            }
        }
    }
}
