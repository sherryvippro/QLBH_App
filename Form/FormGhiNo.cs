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
    public partial class FormGhiNo : Form
    {
        QLBanHangDBEntities db = new QLBanHangDBEntities();
        AutomaticCodeGeneration codeGeneration = new AutomaticCodeGeneration();
        public FormGhiNo()
        {
            InitializeComponent();
        }

        private void FormGhiNo_Load(object sender, EventArgs e)
        {
            cboLoaiSP.DisplayMember = "TenLoai";
            cboLoaiSP.ValueMember = "MaLoai";
            cboLoaiSP.DataSource = db.LoaiHangs.ToList();

            cboLoaiSP.SelectedIndex = -1;
        }


        private void cboLoaiSP_SelectedValueChanged(object sender, EventArgs e)
        {
            var product = db.SanPhams.Where(x => x.LoaiSP == cboLoaiSP.SelectedValue).ToList();
            cboTenSP.DisplayMember = "TenSP";
            cboTenSP.ValueMember = "MaSP";
            cboTenSP.DataSource = product;
            /*if (cboTenSP.DataBindings.Count <= 0)
            {
                MessageBox.Show("Loại hàng này chưa có sản phẩm, vui lòng chọn loại hàng khác!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
            txtDonGia.Text = "";
            txtSL.Text = "";
            txtThanhTien.Text = "";

            cboTenSP.Text = "";
        }

        private void cboTenSP_SelectedValueChanged(object sender, EventArgs e)
        {
            var dongia = db.SanPhams.Where(x => x.MaSP == cboTenSP.SelectedValue).Select(x => x.GiaBan).FirstOrDefault();
            txtDonGia.Text = dongia.ToString();
        }

        private void txtSL_TextChanged(object sender, EventArgs e)
        {
            if(txtSL.Text == "")
            {
                txtThanhTien.Text = "";
            } else txtThanhTien.Text = (decimal.Parse(txtDonGia.Text) * int.Parse(txtSL.Text)).ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string MaKH = codeGeneration.CodeGeneration("KhachHang", "MaKH", "KH");
            string MaHDB = codeGeneration.CodeGeneration("HDBan", "MaHDB", "HDB");
            if (txtTenKH.Text == "" || cboLoaiSP.Text == "" || cboTenSP.Text == "" || txtSL.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var product = db.SanPhams.Where(x => x.MaSP == cboTenSP.SelectedValue).FirstOrDefault();
                if (product.SoLuong == 0)
                {
                    MessageBox.Show("Sản phẩm này số lượng còn 0, không thể bán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (product.SoLuong - int.Parse(txtSL.Text) < 0)
                    {
                        MessageBox.Show("Sản phẩm này số lượng chỉ còn " + product.SoLuong, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    else
                    {
                        if (MessageBox.Show("Bạn có muốn thêm người này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {


                            //Nếu chưa có kh, thêm kh
                            var kh = db.KhachHangs.Where(x => x.MaKH == MaKH || x.TenKH == txtTenKH.Text).FirstOrDefault();
                            if (kh == null)
                            {
                                db.KhachHangs.Add(new KhachHang()
                                {
                                    MaKH = MaKH,
                                    TenKH = txtTenKH.Text.ToLower(),
                                    TrangThai = "Chưa trả nợ"
                                });
                                db.HDBans.Add(new HDBan()
                                {
                                    MaHDB = MaHDB,
                                    MaKH = MaKH,
                                    NgayBan = dtpNgayMua.Value.Date,
                                    TongTien = 0
                                });
                                db.ChiTietHDBs.Add(new ChiTietHDB()
                                {
                                    MaHDB = MaHDB,
                                    MaSP = cboTenSP.SelectedValue.ToString(),
                                    SLBan = int.Parse(txtSL.Text),
                                    ThanhTien = decimal.Parse(txtThanhTien.Text)
                                });
                                db.SaveChanges();
                                // cập nhật sl
                                product.SoLuong -= int.Parse(txtSL.Text);
                                // cập nhật tổng tiền
                                var invoice = db.HDBans.Where(x => x.MaHDB == MaHDB).FirstOrDefault();
                                invoice.TongTien += decimal.Parse(txtThanhTien.Text);
                            }
                            else
                            {
                                
                                // lấy ra mã kh đã có
                                string makhach = kh.MaKH;
                                // Nếu chưa có mã hd, thêm hdb
                                var hdb = db.HDBans.Where(x => x.MaKH == makhach && x.NgayBan == dtpNgayMua.Value.Date).FirstOrDefault();
                                if (hdb == null)
                                {
                                    db.HDBans.Add(new HDBan()
                                    {
                                        MaHDB = MaHDB,
                                        MaKH = makhach,
                                        NgayBan = dtpNgayMua.Value.Date,
                                        TongTien = 0

                                    });
                                    db.ChiTietHDBs.Add(new ChiTietHDB()
                                    {
                                        MaHDB = MaHDB,
                                        MaSP = cboTenSP.SelectedValue.ToString(),
                                        SLBan = int.Parse(txtSL.Text),
                                        ThanhTien = decimal.Parse(txtThanhTien.Text)
                                    });
                                    db.SaveChanges();

                                    // cập nhật sl

                                    product.SoLuong -= int.Parse(txtSL.Text);


                                    // cập nhật tổng tiền
                                    var invoice = db.HDBans.Where(x => x.MaHDB == MaHDB).FirstOrDefault();
                                    invoice.TongTien += decimal.Parse(txtThanhTien.Text);
                                }
                                else
                                {
                                    // đã có mã hdb
                                    //Thêm chi tiết hdb
                                    var tchitiethdb = db.ChiTietHDBs.Where(x => x.MaHDB == hdb.MaHDB && x.MaSP == cboTenSP.SelectedValue).FirstOrDefault();
                                    if (tchitiethdb != null)
                                    {
                                        tchitiethdb.SLBan += int.Parse(txtSL.Text);
                                    }
                                    else
                                    {


                                        db.ChiTietHDBs.Add(new ChiTietHDB()
                                        {
                                            MaHDB = hdb.MaHDB,
                                            MaSP = cboTenSP.SelectedValue.ToString(),
                                            SLBan = int.Parse(txtSL.Text),
                                            ThanhTien = decimal.Parse(txtThanhTien.Text)
                                        });
                                    }
                                    // cập nhật sl
                                    product.SoLuong -= int.Parse(txtSL.Text);
                                    // cập nhật tổng tiền
                                    var invoice = db.HDBans.Where(x => x.MaHDB == hdb.MaHDB).FirstOrDefault();
                                    invoice.TongTien += decimal.Parse(txtThanhTien.Text);
                                }

                            }
                            MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtTenKH.Text = string.Empty;
                            txtSL.Text = string.Empty;
                            txtThanhTien.Text = string.Empty;
                            cboLoaiSP.SelectedIndex = -1;
                            cboTenSP.SelectedIndex = -1;
                        }
                    }
                }

                db.SaveChanges();

            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            FormDSNo formDSNo = new FormDSNo();
            formDSNo.Show();
        }

        private void txtSL_KeyPress(object sender, KeyPressEventArgs e)
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
