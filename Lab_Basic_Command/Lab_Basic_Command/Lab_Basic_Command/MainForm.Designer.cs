using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab_Basic_Command
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private FlowLayoutPanel flowLayoutPanelTables;
        private ComboBox comboCategory;
        private ComboBox comboFood;
        private NumericUpDown numericQuantity;
        private Button btnAddFood;
        private Button btnCheckout;
        private DataGridView dataGridViewBill;
        private TextBox txtTotal;
        private Label lblTotal;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.flowLayoutPanelTables = new FlowLayoutPanel();
            this.comboCategory = new ComboBox();
            this.comboFood = new ComboBox();
            this.numericQuantity = new NumericUpDown();
            this.btnAddFood = new Button();
            this.btnCheckout = new Button();
            this.dataGridViewBill = new DataGridView();
            this.txtTotal = new TextBox();
            this.lblTotal = new Label();

            ((System.ComponentModel.ISupportInitialize)(this.numericQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBill)).BeginInit();
            this.SuspendLayout();

            // flowLayoutPanelTables
            this.flowLayoutPanelTables.Location = new Point(10, 20);
            this.flowLayoutPanelTables.Size = new Size(220, 400);
            this.flowLayoutPanelTables.AutoScroll = true;

            // comboCategory
            this.comboCategory.Location = new Point(250, 20);
            this.comboCategory.Size = new Size(180, 24);
            this.comboCategory.SelectedIndexChanged += new EventHandler(comboCategory_SelectedIndexChanged);

            // comboFood
            this.comboFood.Location = new Point(440, 20);
            this.comboFood.Size = new Size(180, 24);

            // numericQuantity
            this.numericQuantity.Location = new Point(630, 20);
            this.numericQuantity.Size = new Size(50, 24);
            this.numericQuantity.Minimum = 1;
            this.numericQuantity.Value = 1;

            // btnAddFood
            this.btnAddFood.Location = new Point(700, 18);
            this.btnAddFood.Size = new Size(80, 30);
            this.btnAddFood.Text = "Thêm món";
            this.btnAddFood.Click += new EventHandler(btnAddFood_Click);

            // dataGridViewBill
            this.dataGridViewBill.Location = new Point(250, 60);
            this.dataGridViewBill.Size = new Size(530, 300);
            this.dataGridViewBill.Columns.Add("TênMón", "Tên Món");
            this.dataGridViewBill.Columns.Add("SốLượng", "Số Lượng");
            this.dataGridViewBill.Columns.Add("ĐơnGiá", "Đơn Giá");
            this.dataGridViewBill.Columns.Add("ThànhTiền", "Thành Tiền");

            // lblTotal
            this.lblTotal.Location = new Point(480, 370);
            this.lblTotal.Size = new Size(100, 30);
            this.lblTotal.Text = "Tổng tiền:";

            // txtTotal
            this.txtTotal.Location = new Point(580, 370);
            this.txtTotal.Size = new Size(100, 30);
            this.txtTotal.ReadOnly = true;

            // btnCheckout
            this.btnCheckout.Location = new Point(690, 370);
            this.btnCheckout.Size = new Size(90, 30);
            this.btnCheckout.Text = "Thanh toán";
            this.btnCheckout.Click += new EventHandler(btnCheckout_Click);

            // MainForm
            this.ClientSize = new Size(800, 420);
            this.Controls.Add(flowLayoutPanelTables);
            this.Controls.Add(comboCategory);
            this.Controls.Add(comboFood);
            this.Controls.Add(numericQuantity);
            this.Controls.Add(btnAddFood);
            this.Controls.Add(dataGridViewBill);
            this.Controls.Add(lblTotal);
            this.Controls.Add(txtTotal);
            this.Controls.Add(btnCheckout);
            this.Text = "Quản Lý Quán Cafe";

            ((System.ComponentModel.ISupportInitialize)(this.numericQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBill)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
