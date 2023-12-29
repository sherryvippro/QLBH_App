using QLBH_App.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBH_App
{
    public partial class EditProducts : Form
    {
        QLBanHangDBEntities qLBanHangDB = new QLBanHangDBEntities();
        public EditProducts()
        {
            InitializeComponent();
        }

        private void EditProducts_Load(object sender, EventArgs e)
        {
            cboLoai.DisplayMember = "TenLoai";
            cboLoai.ValueMember = "MaLoai";
            cboLoai.DataSource = qLBanHangDB.LoaiHangs.ToList();

            txtMaSP.Text = Form1.list[0];
            txtTenSP.Text = Form1.list[1];
            cboLoai.Text = Form1.list[2];
            txtGiaNhap.Text = Form1.list[3];
            txtGiaBan.Text = Form1.list[4];
            dtpHSD.Text = Form1.list[5];
            txtSL.Text = Form1.list[6];

            txtMaSP.ReadOnly = true;

            var maloai = qLBanHangDB.LoaiHangs.Where(x => x.TenLoai == cboLoai.Text).Select(x => x.MaLoai).FirstOrDefault();
            cboLoai.SelectedValue = maloai;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Form1.list.Clear();
            this.Close();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string id = Form1.list[0];

            SanPham product = (from c in qLBanHangDB.SanPhams
                               join b in qLBanHangDB.LoaiHangs
                               on c.LoaiSP equals b.MaLoai
                               where c.MaSP == id
                               select c).FirstOrDefault();
            if (product != null)
            {
                product.TenSP = txtTenSP.Text;
                product.LoaiSP = cboLoai.SelectedValue.ToString();
                product.GiaNhap = decimal.Parse(txtGiaNhap.Text);
                product.GiaBan = decimal.Parse(txtGiaBan.Text);
                product.HSD = dtpHSD.Value.Date;
                product.SoLuong = int.Parse(txtSL.Text);
                qLBanHangDB.SaveChanges();
                MessageBox.Show("Sửa thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không tìm thấy sản phẩm");

            }


        }

        private void txtGiaBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Xác thực rằng phím vừa nhấn không phải CTRL hoặc không phải dạng số
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // Nếu bạn muốn, bạn có thể cho phép nhập số thực với dấu chấm
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        

        private void EditProducts_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1.list.Clear();

        }
    }
}
