using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace AppXoSO
{
    public partial class Form1 : Form
    {
        private List<KetQuaXoSo> allResults = new List<KetQuaXoSo>();
        private XuLyXoSo xl = new XuLyXoSo();
        

        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            
        }

        private void dgvKetQua_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var tinh = dgvKetQua.Rows[e.RowIndex].Cells["Tỉnh/Đài"].Value?.ToString() ?? "";
            var entry = allResults.FirstOrDefault(x => x.Tinh == tinh);
            if (entry != null)
            {
                string description = BuildDescriptionText(entry);
                var frm = new FormChiTiet($"[{entry.Tinh}]", description, entry.Ngay?.ToString("dd/MM/yyyy") ?? "");
                frm.ShowDialog();
            }
        }

        private string BuildDescriptionText(KetQuaXoSo e)
        {
            var sb = new System.Text.StringBuilder();
            sb.AppendLine($"[{e.Tinh}]");
            if (e.GiaiDB.Any()) sb.AppendLine("DB: " + string.Join(" - ", e.GiaiDB));
            if (e.Giai1.Any()) sb.AppendLine("1: " + string.Join(" - ", e.Giai1));
            if (e.Giai2.Any()) sb.AppendLine("2: " + string.Join(" - ", e.Giai2));
            if (e.Giai3.Any()) sb.AppendLine("3: " + string.Join(" - ", e.Giai3));
            if (e.Giai4.Any()) sb.AppendLine("4: " + string.Join(" - ", e.Giai4));
            if (e.Giai5.Any()) sb.AppendLine("5: " + string.Join(" - ", e.Giai5));
            if (e.Giai6.Any()) sb.AppendLine("6: " + string.Join(" - ", e.Giai6));
            if (e.Giai7.Any()) sb.AppendLine("7: " + string.Join(" - ", e.Giai7));
            return sb.ToString();
        }

        private string KiemTraTrungSoTrongKetQua(string soCanDo, KetQuaXoSo kq)
        {
            bool Match(string s) => s.EndsWith(soCanDo);

            if (kq.GiaiDB.Any(x => Match(x))) return "Giải Đặc Biệt";
            if (kq.Giai1.Any(x => Match(x))) return "Giải Nhất";
            if (kq.Giai2.Any(x => Match(x))) return "Giải Nhì";
            if (kq.Giai3.Any(x => Match(x))) return "Giải Ba";
            if (kq.Giai4.Any(x => Match(x))) return "Giải Tư";
            if (kq.Giai5.Any(x => Match(x))) return "Giải Năm";
            if (kq.Giai6.Any(x => Match(x))) return "Giải Sáu";
            if (kq.Giai7.Any(x => Match(x))) return "Giải Bảy";

            return "";
        }


        private void btnKiemTra_Click(object sender, EventArgs e)
        {
            string soCanDo = txtSo.Text.Trim();
            string tinh = cboDai.SelectedItem?.ToString() ?? "";
            DateTime ngay = dtNgay.Value.Date;
            foreach (var item in allResults)
            {
                if(item.Tinh == tinh && item.Ngay?.Date == ngay)
                {
                    string ketQua = KiemTraTrungSoTrongKetQua(soCanDo, item);
                    if (ketQua != "")
                    {
                        MessageBox.Show($"Chúc mừng! Số {soCanDo} trúng {ketQua} của đài {tinh} ngày {ngay:dd/MM/yyyy}.", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Rất tiếc! Số {soCanDo} không trúng giải nào của đài {tinh} ngày {ngay:dd/MM/yyyy}.", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    return;
                }
            }
        }


        private void cbVung_SelectedIndexChanged(object sender, EventArgs e)
        {
            string rssUrl = "";
            switch (cbVung.SelectedIndex)
            {
                case 0: rssUrl = "https://xskt.com.vn/rss-feed/mien-bac-xsmb.rss"; break;
                case 1: rssUrl = "https://xskt.com.vn/rss-feed/mien-trung-xsmt.rss"; break;
                case 2: rssUrl = "https://xskt.com.vn/rss-feed/mien-nam-xsmn.rss"; break;
            }

            try
            {
                allResults.Clear();

                XmlDocument xml = new XmlDocument();
                xml.Load(rssUrl);

                XmlNodeList items = xml.GetElementsByTagName("item");
                foreach (XmlNode item in items)
                {
                    string title = item["title"]?.InnerText ?? "";
                    string description = item["description"]?.InnerText ?? "";
                    DateTime pubDate = DateTime.Now;
                    DateTime.TryParse(item["pubDate"]?.InnerText, out pubDate);

                    var list = xl.TachDescription(title, description, pubDate);
                    allResults.AddRange(list);
                }

                // ✅ Lấy danh sách đài từ allResults để fill vào cboDai
                var dsDai = allResults
                    .Select(r => r.Tinh)
                    .Where(t => !string.IsNullOrEmpty(t))
                    .Distinct()
                    .ToList();

                cboDai.Items.Clear();
                foreach (var dai in dsDai)
                    cboDai.Items.Add(dai);

                if (cboDai.Items.Count > 0)
                    cboDai.SelectedIndex = 0;

                // Hiển thị ra DataGridView
                var dt = new DataTable();
                dt.Columns.Add("Tỉnh/Đài");
                dt.Columns.Add("Ngày");
                dt.Columns.Add("DB");
                dt.Columns.Add("G1");
                dt.Columns.Add("G2");
                dt.Columns.Add("G3");
                dt.Columns.Add("G4");
                dt.Columns.Add("G5");
                dt.Columns.Add("G6");
                dt.Columns.Add("G7");

                foreach (var r in allResults)
                {
                    var row = dt.NewRow();
                    row["Tỉnh/Đài"] = r.Tinh;
                    row["Ngày"] = r.Ngay?.ToString("yyyy-MM-dd") ?? "";
                    row["DB"] = string.Join(" - ", r.GiaiDB);
                    row["G1"] = string.Join(" - ", r.Giai1);
                    row["G2"] = string.Join(" - ", r.Giai2);
                    row["G3"] = string.Join(" - ", r.Giai3);
                    row["G4"] = string.Join(" - ", r.Giai4);
                    row["G5"] = string.Join(" - ", r.Giai5);
                    row["G6"] = string.Join(" - ", r.Giai6);
                    row["G7"] = string.Join(" - ", r.Giai7);
                    dt.Rows.Add(row);
                }

                dgvKetQua.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }


        private void cboMien_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        

        private void dgvKetQua_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void cboDai_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
