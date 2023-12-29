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
    public partial class NhapThongTin : Form
    {
        QLBanHangDBEntities qLBanHangDB = new QLBanHangDBEntities();
        AutomaticCodeGeneration genCode = new AutomaticCodeGeneration();
        public NhapThongTin()
        {
            InitializeComponent();
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaSP.Text = genCode.CodeGeneration("SanPham", "MaSP", "SP");
            txtTenSP.Text = string.Empty;
            txtSL.Text = string.Empty;
            txtGiaNhap.Text = string.Empty;
            txtGiaBan.Text = string.Empty;
            cboLoai.Text = string.Empty;
        }

        private void NhapThongTin_Load(object sender, EventArgs e)
        {
            cboLoai.DisplayMember = "TenLoai";
            cboLoai.ValueMember = "MaLoai";
            cboLoai.DataSource = qLBanHangDB.LoaiHangs.ToList();

            txtMaSP.ReadOnly = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaSP.Text == "" || txtTenSP.Text == "" || txtGiaBan.Text == "" || txtSL.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (MessageBox.Show("Bạn có muốn thêm " + txtTenSP.Text + " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    qLBanHangDB.SanPhams.Add(new SanPham()
                    {
                        MaSP = txtMaSP.Text,
                        TenSP = txtTenSP.Text,
                        LoaiSP = cboLoai.SelectedValue.ToString(),
                        GiaNhap = decimal.Parse(txtGiaNhap.Text),
                        GiaBan = decimal.Parse(txtGiaBan.Text),
                        HSD = Convert.ToDateTime(dtpHSD.Value).Date,
                        SoLuong = int.Parse(txtSL.Text),
                    });
                    qLBanHangDB.SaveChanges();
                    MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtGiaNhap_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
