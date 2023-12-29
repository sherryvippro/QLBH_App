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
    public partial class FormDSNo : Form
    {
        QLBanHangDBEntities db = new QLBanHangDBEntities();

        public FormDSNo()
        {
            InitializeComponent();
        }
        private void FormDSNo_Load(object sender, EventArgs e)
        {
            var lstKH = from b in db.KhachHangs
                        join c in db.HDBans
                        on b.MaKH equals c.MaKH
                        join d in db.ChiTietHDBs
                        on c.MaHDB equals d.MaHDB
                        join g in db.SanPhams
                        on d.MaSP equals g.MaSP
                        where b.TrangThai != "Đã trả nợ"
                        select new
                        {
                            TenKH = b.TenKH,
                            TenSP = g.TenSP,
                            LoaiSP = g.LoaiHang.TenLoai,
                            GiaBan = g.GiaBan,
                            SL = d.SLBan,
                            TT = d.ThanhTien,
                            TongTien = c.TongTien,
                            NgayBan = c.NgayBan,
                            TrangThai = b.TrangThai
                        };

            var lstKH_DaTraTien = from b in db.KhachHangs
                                  join c in db.ThanhToans on
                                  b.MaKH equals c.MaKH
                                  select new
                                  {
                                      MaKH = b.MaKH,
                                      TenKH = b.TenKH,
                                      SoTien = c.SoTienDaTra,
                                      NgayTra = c.NgayTra,
                                      TrangThai = b.TrangThai
                                  };

            dgvDS.DataSource = lstKH.ToList();
            dgvTraTien.DataSource = lstKH_DaTraTien.ToList();

            dgvDS.Columns[0].HeaderText = "Tên khách";
            dgvDS.Columns[1].HeaderText = "Tên SP";
            dgvDS.Columns[2].HeaderText = "Loại hàng";
            dgvDS.Columns[3].HeaderText = "Giá bán";
            dgvDS.Columns[4].HeaderText = "Số lượng";
            dgvDS.Columns[5].HeaderText = "Thành tiền";
            dgvDS.Columns[6].HeaderText = "Tổng tiền";
            dgvDS.Columns[7].HeaderText = "Ngày bán";
            dgvDS.Columns[8].HeaderText = "Trạng thái";

            dgvTraTien.Columns[0].HeaderText = "Mã KH";
            dgvTraTien.Columns[1].HeaderText = "Tên khách";
            dgvTraTien.Columns[2].HeaderText = "Số tiền đã trả";
            dgvTraTien.Columns[3].HeaderText = "Ngày trả";
            dgvTraTien.Columns[4].HeaderText = "Trạng thái";

            dgvDS.Columns[1].Width = 200;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            FormDSNo_Load(sender, e);
            cbTrangThai.Checked = false;
            txtSearch.Text = "";
        }

        private void cbTrangThai_CheckedChanged(object sender, EventArgs e)
        {
            var status = from b in db.KhachHangs
                         join c in db.HDBans
                         on b.MaKH equals c.MaKH
                         join d in db.ChiTietHDBs
                         on c.MaHDB equals d.MaHDB
                         join g in db.SanPhams
                         on d.MaSP equals g.MaSP
                         select new
                         {
                             TenKH = b.TenKH,
                             TenSP = g.TenSP,
                             LoaiSP = g.LoaiHang.TenLoai,
                             GiaBan = g.GiaBan,
                             SL = d.SLBan,
                             TT = d.ThanhTien,
                             TongTien = c.TongTien,
                             NgayBan = c.NgayBan,
                             TrangThai = b.TrangThai
                         };
            if (cbTrangThai.Checked)
            {
                dgvDS.DataSource = status.Where(x => x.TrangThai == "Chưa trả nợ").ToList();
            }
            else dgvDS.DataSource = status.ToList();
        }

        private void txtDaTra_KeyPress(object sender, KeyPressEventArgs e)
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

        private void dgvDS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtHT.Text = dgvDS.CurrentRow.Cells[0].Value.ToString();
            string makh = db.KhachHangs.Where(x => x.TenKH == txtHT.Text).Select(x => x.MaKH).FirstOrDefault();
            double tongtien = ((double)db.HDBans.Where(x => x.MaKH == makh).Sum(x => x.TongTien));
            var khDaTraTien = db.ThanhToans.Where(x => x.MaKH == makh).Sum(x => x.SoTienDaTra);
            double tienno = 0;
            if(khDaTraTien == null)
            {
                tienno = tongtien;

            } else tienno = tongtien - (double)khDaTraTien;
            txtTienNo.Text = tienno.ToString();
            if (txtTienNo.Text == "0")
                txtDaTra.ReadOnly = true;
            if (dgvDS.CurrentRow.Cells[8].Value.ToString() == "Đã trả nợ")
            {
                txtDaTra.Text = txtTienNo.Text;
                txtConLai.Text = "0";
            }
            else
            {
                txtDaTra.Text = "0";
                txtConLai.Text = tienno.ToString();
            }
        }

        private void txtDaTra_TextChanged(object sender, EventArgs e)
        {
            if (txtDaTra.Text != "0" && txtDaTra.Text != "")
            {
                btnEdit.Visible = true;
                txtConLai.Text = (int.Parse(txtTienNo.Text) - int.Parse(txtDaTra.Text)).ToString();
            }
            else { btnEdit.Visible = false; txtConLai.Text = txtTienNo.Text; }
        }

        private void txtConLai_TextChanged(object sender, EventArgs e)
        {
            if (txtConLai.Text == "0")
            {
                txtStatus.Text = "Đã trả xong";
            }
            else
            {
                txtStatus.Text = "Chưa trả xong";
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string name = txtSearch.Text;
            var lstKH = from b in db.KhachHangs
                        join c in db.HDBans
                        on b.MaKH equals c.MaKH
                        join d in db.ChiTietHDBs
                        on c.MaHDB equals d.MaHDB
                        join g in db.SanPhams
                        on d.MaSP equals g.MaSP
                        select new
                        {
                            TenKH = b.TenKH,
                            TenSP = g.TenSP,
                            LoaiSP = g.LoaiHang.TenLoai,
                            GiaBan = g.GiaBan,
                            SL = d.SLBan,
                            TT = d.ThanhTien,
                            TongTien = c.TongTien,
                            NgayBan = c.NgayBan,
                            TrangThai = b.TrangThai
                        };
            dgvDS.DataSource = lstKH.Where(x => x.TenKH.Contains(name)).ToList();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string makh = db.KhachHangs.Where(x => x.TenKH == txtHT.Text).Select(x => x.MaKH).FirstOrDefault();
            if (makh == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ThanhToan thanhToan = new ThanhToan()
                {
                    MaKH = makh,
                    SoTienDaTra = decimal.Parse(txtDaTra.Text),
                    NgayTra = dtpNgayTraNo.Value
                };
                KhachHang khachHang = db.KhachHangs.Where(x => x.MaKH == makh).FirstOrDefault();
                switch (txtStatus.Text)
                {
                    case "Đã trả xong":
                        khachHang.TrangThai = "Đã trả nợ";
                        break;
                    case "Chưa trả xong":
                        khachHang.TrangThai = "Chưa trả nợ";
                        break;
                }
                if(MessageBox.Show("Bạn có muốn lưu không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    db.ThanhToans.Add(thanhToan);
                    
                    db.SaveChanges();
                    FormDSNo_Load(sender, e);
                }
            }
        }
    }
}
