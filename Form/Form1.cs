using QLBH_App.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBH_App
{
    public partial class Form1 : Form
    {
        QLBanHangDBEntities qLBanHangDB = new QLBanHangDBEntities();
        public static List<string> list = new List<string>();
        public Form1()
        {
            InitializeComponent();

        }
        public void LoadForm()
        {
            var result = from c in qLBanHangDB.SanPhams
                         join b in qLBanHangDB.LoaiHangs
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
                         };
            dgvSP.DataSource = result.ToList();
            dgvSP.Columns[1].Width = 300;

            dgvSP.Columns[0].HeaderText = "Mã SP";
            dgvSP.Columns[1].HeaderText = "Tên SP";
            dgvSP.Columns[2].HeaderText = "Loại hàng";
            dgvSP.Columns[3].HeaderText = "Giá nhập";
            dgvSP.Columns[4].HeaderText = "Giá bán";
            dgvSP.Columns[6].HeaderText = "Số lượng";

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void mnuAddSP_Click(object sender, EventArgs e)
        {
            NhapThongTin frmInfo = new NhapThongTin();
            frmInfo.ShowDialog();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadForm();
            txtTK.Text = "";
        }

        private void dgvSP_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 0; i < 7; i++)
            {
                list.Add(dgvSP.CurrentRow.Cells[i].Value.ToString());
            }
            EditProducts editProducts = new EditProducts();
            editProducts.ShowDialog();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            var product = qLBanHangDB.SanPhams.Where(t => t.TenSP.Contains(txtTK.Text)
                            || t.LoaiHang.TenLoai.Contains(txtTK.Text)).Select(x => new
                            {
                                MaSP = x.MaSP,
                                TenSP = x.TenSP,
                                LoaiHang = x.LoaiHang.TenLoai,
                                GiaNhap = x.GiaNhap,
                                GiaBan = x.GiaBan,
                                HSD = x.HSD,
                                SoLuong = x.SoLuong
                            }).ToList();
            if (product.Count > 0)
            {
                dgvSP.DataSource = product.ToList();
            }
            else MessageBox.Show("Không tìm thấy sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            /*int count = product.ToList().Count;
            if(count <= 0)
            {
                MessageBox.Show("Không tìm thấy sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else dgvSP.DataSource = product.ToList();*/


        }

        private void mnuLoaiHang_Click(object sender, EventArgs e)
        {
            FormLoaiHang frmLoaiHang = new FormLoaiHang();
            frmLoaiHang.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            FormHSD formHSD = new FormHSD();
            formHSD.Show();
        }

        private void mnuGhiNo_Click(object sender, EventArgs e)
        {
            FormGhiNo formGhiNo = new FormGhiNo();
            formGhiNo.Show();
        }

        private void mnuLstNo_Click(object sender, EventArgs e)
        {
            FormDSNo formDSNo = new FormDSNo();
            formDSNo.Show();
        }
    }
}
