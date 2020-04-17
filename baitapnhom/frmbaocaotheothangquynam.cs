using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace baitapnhom
{
    public partial class frmbaocaotheothangquynam : Form
    {
        public frmbaocaotheothangquynam()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hienthi();
        }

        private void frmbaocaotheothangquynam_Load(object sender, EventArgs e)
        {
            DAO.connect();
           
        }
        private void hienthi()
        {
            string sql = "select sum(DATEDIFF(day,c.ngaythue,f.ngaytra)*(a.dongiathue)+i.tienphat) as [doanh thu la:] from sachtruyen a join chitietthuesach b on a.masach = b.masach join thuesach c on c.mathue = b.mathue join chitiettrasach d on d.masach = a.masach join trasach f on f.matra = d.matra join vipham i on i.mavipham = d.mavipham where datepart(month,f.ngaytra)='" + txtdtt.Text + "' and datepart(year, f.ngaytra) = '" + txtnam.Text + "'";
            SqlDataAdapter adp = new SqlDataAdapter(sql, DAO.con);
            DataTable tblchitiettrasach = new DataTable();
            adp.Fill(tblchitiettrasach);
            dataGridView1.DataSource = tblchitiettrasach;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sql = "select sum(DATEDIFF(day,c.ngaythue,f.ngaytra)*(a.dongiathue)+i.tienphat) as [doanh thu la:] from sachtruyen a join chitietthuesach b on a.masach = b.masach join thuesach c on c.mathue = b.mathue join chitiettrasach d on d.masach = a.masach join trasach f on f.matra = d.matra join vipham i on i.mavipham = d.mavipham where datepart(year, f.ngaytra) = '" + txtnam.Text + "'";
            SqlDataAdapter adp = new SqlDataAdapter(sql, DAO.con);
            DataTable tblchitiettrasach = new DataTable();
            adp.Fill(tblchitiettrasach);
            dataGridView1.DataSource = tblchitiettrasach;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            exexcel ex = new exexcel();
            DataTable dt = (DataTable)dataGridView1.DataSource;
            ex.Export(dt, "Danh sach", "Báo cáo tổng tiền thu");
        }
    }
}
