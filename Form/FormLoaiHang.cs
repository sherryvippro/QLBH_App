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
    public partial class FormLoaiHang : Form
    {
        QLBanHangDBEntities db = new QLBanHangDBEntities();
        private string id;
        AutomaticCodeGeneration codeGeneration = new AutomaticCodeGeneration();
        public FormLoaiHang()
        {
            InitializeComponent();
        }

        private void LoaiHang_Load(object sender, EventArgs e)
        {
            var lstLoai = db.LoaiHangs.Select(x => new { MaLoai = x.MaLoai, TenLoai = x.TenLoai }).ToList();
            dgvLoaiHang.DataSource = lstLoai;

            dgvLoaiHang.Columns[0].HeaderText = "Mã loại";
            dgvLoaiHang.Columns[1].HeaderText = "Tên loại";

            btnSua.Enabled = false;
        }



        private void btnThem_Click(object sender, EventArgs e)
        {
            var loaihang = db.LoaiHangs.Where(x => x.TenLoai == txtTenLoai.Text).FirstOrDefault();
            string maloai = codeGeneration.CodeGeneration("LoaiHang", "MaLoai", "M");
            if (txtTenLoai.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (loaihang != null)
            {
                MessageBox.Show("Loại hàng này đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (MessageBox.Show("Bạn có muốn thêm " + txtTenLoai.Text + " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    db.LoaiHangs.Add(new LoaiHang()
                    {
                        MaLoai = maloai,
                        TenLoai = txtTenLoai.Text
                    });
                    db.SaveChanges();
                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoaiHang_Load(sender, e);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            LoaiHang loaiHang = db.LoaiHangs.Where(x => x.MaLoai == id).FirstOrDefault();
            if (loaiHang != null)
            {
                loaiHang.TenLoai = txtTenLoai.Text;

                db.SaveChanges();
                MessageBox.Show("Sửa thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoaiHang_Load(sender, e);
            }
        }

        private void dgvLoaiHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSua.Enabled = true;
            txtTenLoai.Text = dgvLoaiHang.CurrentRow.Cells[1].Value.ToString();
            id = dgvLoaiHang.CurrentRow.Cells[0].Value.ToString();
        }
    }
}
