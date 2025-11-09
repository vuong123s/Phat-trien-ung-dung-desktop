using System.Windows.Forms;

namespace RestaurantManagementProject
{
    partial class frmMain
    {
        private System.ComponentModel.IContainer components = null;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem mnsHeThong;
        private ToolStripMenuItem menuLogout;
        private ToolStripMenuItem menuExit;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblWelcome;
        private ToolStripStatusLabel lblAccountInfo;
        private SplitContainer splitContainer1;
        private GroupBox grpTables;
        private FlowLayoutPanel flpTables;
        private GroupBox grpOrder;
        private GroupBox grpFoods;
        private DataGridView dgvFoods;
        private TextBox txtSearchFood;
        private Label lblSearchFood;
        private ComboBox cboCategory;
        private Label lblCategory;
        private NumericUpDown nudQuantity;
        private Label lblQuantity;
        private Button btnAddFood;
        private Label lblCurrentTable;
        private Button btnCreateOrder;
        private TextBox txtDiscount;
        private Label lblDiscount;
        private TextBox txtTax;
        private Label lblTax;
        private Label lblSubTotal;
        private Label lblFinalTotal;
        private Label lblSubTotalText;
        private Label lblFinalTotalText;
        private Button btnClearOrder;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnsHeThong = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblWelcome = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblAccountInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grpTables = new System.Windows.Forms.GroupBox();
            this.flpTables = new System.Windows.Forms.FlowLayoutPanel();
            this.grpOrder = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvOrderDetails = new System.Windows.Forms.DataGridView();
            this.btnClearOrder = new System.Windows.Forms.Button();
            this.lblFinalTotalText = new System.Windows.Forms.Label();
            this.lblSubTotalText = new System.Windows.Forms.Label();
            this.lblFinalTotal = new System.Windows.Forms.Label();
            this.lblSubTotal = new System.Windows.Forms.Label();
            this.btnCreateOrder = new System.Windows.Forms.Button();
            this.lblTax = new System.Windows.Forms.Label();
            this.txtTax = new System.Windows.Forms.TextBox();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.lblCurrentTable = new System.Windows.Forms.Label();
            this.grpFoods = new System.Windows.Forms.GroupBox();
            this.btnAddFood = new System.Windows.Forms.Button();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.nudQuantity = new System.Windows.Forms.NumericUpDown();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.lblSearchFood = new System.Windows.Forms.Label();
            this.txtSearchFood = new System.Windows.Forms.TextBox();
            this.dgvFoods = new System.Windows.Forms.DataGridView();
            this.tsmiQLTK = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiQLHD = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiQLLM = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiQLM = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiQLBan = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grpTables.SuspendLayout();
            this.grpOrder.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderDetails)).BeginInit();
            this.grpFoods.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFoods)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnsHeThong});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1600, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnsHeThong
            // 
            this.mnsHeThong.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuLogout,
            this.menuExit,
            this.tsmiQLTK,
            this.tsmiQLHD,
            this.tsmiQLLM,
            this.tsmiQLM,
            this.tsmiQLBan});
            this.mnsHeThong.Name = "mnsHeThong";
            this.mnsHeThong.Size = new System.Drawing.Size(85, 24);
            this.mnsHeThong.Text = "Hệ thống";
            // 
            // menuLogout
            // 
            this.menuLogout.Name = "menuLogout";
            this.menuLogout.Size = new System.Drawing.Size(224, 26);
            this.menuLogout.Text = "Đăng xuất";
            this.menuLogout.Click += new System.EventHandler(this.menuLogout_Click);
            // 
            // menuExit
            // 
            this.menuExit.Name = "menuExit";
            this.menuExit.Size = new System.Drawing.Size(224, 26);
            this.menuExit.Text = "Thoát";
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblWelcome,
            this.lblAccountInfo});
            this.statusStrip1.Location = new System.Drawing.Point(0, 784);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1600, 30);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblWelcome
            // 
            this.lblWelcome.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.lblWelcome.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(790, 24);
            this.lblWelcome.Spring = true;
            this.lblWelcome.Text = "Xin chào:";
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAccountInfo
            // 
            this.lblAccountInfo.Name = "lblAccountInfo";
            this.lblAccountInfo.Size = new System.Drawing.Size(790, 24);
            this.lblAccountInfo.Spring = true;
            this.lblAccountInfo.Text = "Tài khoản:";
            this.lblAccountInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 28);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grpTables);
            this.splitContainer1.Panel1.Controls.Add(this.grpOrder);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grpFoods);
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(1600, 756);
            this.splitContainer1.SplitterDistance = 366;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 2;
            // 
            // grpTables
            // 
            this.grpTables.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grpTables.Controls.Add(this.flpTables);
            this.grpTables.Location = new System.Drawing.Point(16, 4);
            this.grpTables.Margin = new System.Windows.Forms.Padding(4);
            this.grpTables.Name = "grpTables";
            this.grpTables.Padding = new System.Windows.Forms.Padding(4);
            this.grpTables.Size = new System.Drawing.Size(800, 358);
            this.grpTables.TabIndex = 0;
            this.grpTables.TabStop = false;
            this.grpTables.Text = "Danh sách bàn";
            // 
            // flpTables
            // 
            this.flpTables.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpTables.AutoScroll = true;
            this.flpTables.Location = new System.Drawing.Point(8, 23);
            this.flpTables.Margin = new System.Windows.Forms.Padding(4);
            this.flpTables.Name = "flpTables";
            this.flpTables.Size = new System.Drawing.Size(784, 327);
            this.flpTables.TabIndex = 0;
            this.flpTables.Paint += new System.Windows.Forms.PaintEventHandler(this.flpTables_Paint);
            // 
            // grpOrder
            // 
            this.grpOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpOrder.Controls.Add(this.groupBox1);
            this.grpOrder.Controls.Add(this.btnClearOrder);
            this.grpOrder.Controls.Add(this.lblFinalTotalText);
            this.grpOrder.Controls.Add(this.lblSubTotalText);
            this.grpOrder.Controls.Add(this.lblFinalTotal);
            this.grpOrder.Controls.Add(this.lblSubTotal);
            this.grpOrder.Controls.Add(this.btnCreateOrder);
            this.grpOrder.Controls.Add(this.lblTax);
            this.grpOrder.Controls.Add(this.txtTax);
            this.grpOrder.Controls.Add(this.lblDiscount);
            this.grpOrder.Controls.Add(this.txtDiscount);
            this.grpOrder.Controls.Add(this.lblCurrentTable);
            this.grpOrder.Location = new System.Drawing.Point(824, 15);
            this.grpOrder.Margin = new System.Windows.Forms.Padding(4);
            this.grpOrder.Name = "grpOrder";
            this.grpOrder.Padding = new System.Windows.Forms.Padding(4);
            this.grpOrder.Size = new System.Drawing.Size(760, 347);
            this.grpOrder.TabIndex = 1;
            this.grpOrder.TabStop = false;
            this.grpOrder.Text = "Order hiện tại";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvOrderDetails);
            this.groupBox1.Location = new System.Drawing.Point(15, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(540, 287);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // dgvOrderDetails
            // 
            this.dgvOrderDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOrderDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderDetails.Location = new System.Drawing.Point(7, 14);
            this.dgvOrderDetails.Margin = new System.Windows.Forms.Padding(4);
            this.dgvOrderDetails.Name = "dgvOrderDetails";
            this.dgvOrderDetails.RowHeadersWidth = 51;
            this.dgvOrderDetails.Size = new System.Drawing.Size(526, 269);
            this.dgvOrderDetails.TabIndex = 1;
            // 
            // btnClearOrder
            // 
            this.btnClearOrder.BackColor = System.Drawing.Color.LightCoral;
            this.btnClearOrder.Location = new System.Drawing.Point(627, 25);
            this.btnClearOrder.Margin = new System.Windows.Forms.Padding(4);
            this.btnClearOrder.Name = "btnClearOrder";
            this.btnClearOrder.Size = new System.Drawing.Size(120, 31);
            this.btnClearOrder.TabIndex = 12;
            this.btnClearOrder.Text = "Xóa Order";
            this.btnClearOrder.UseVisualStyleBackColor = false;
            this.btnClearOrder.Click += new System.EventHandler(this.btnClearOrder_Click);
            // 
            // lblFinalTotalText
            // 
            this.lblFinalTotalText.AutoSize = true;
            this.lblFinalTotalText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblFinalTotalText.Location = new System.Drawing.Point(570, 222);
            this.lblFinalTotalText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFinalTotalText.Name = "lblFinalTotalText";
            this.lblFinalTotalText.Size = new System.Drawing.Size(83, 18);
            this.lblFinalTotalText.TabIndex = 11;
            this.lblFinalTotalText.Text = "Tổng tiền:";
            // 
            // lblSubTotalText
            // 
            this.lblSubTotalText.AutoSize = true;
            this.lblSubTotalText.Location = new System.Drawing.Point(570, 186);
            this.lblSubTotalText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSubTotalText.Name = "lblSubTotalText";
            this.lblSubTotalText.Size = new System.Drawing.Size(61, 16);
            this.lblSubTotalText.TabIndex = 10;
            this.lblSubTotalText.Text = "Tạm tính:";
            // 
            // lblFinalTotal
            // 
            this.lblFinalTotal.AutoSize = true;
            this.lblFinalTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblFinalTotal.ForeColor = System.Drawing.Color.Red;
            this.lblFinalTotal.Location = new System.Drawing.Point(669, 221);
            this.lblFinalTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFinalTotal.Name = "lblFinalTotal";
            this.lblFinalTotal.Size = new System.Drawing.Size(19, 20);
            this.lblFinalTotal.TabIndex = 9;
            this.lblFinalTotal.Text = "0";
            // 
            // lblSubTotal
            // 
            this.lblSubTotal.AutoSize = true;
            this.lblSubTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblSubTotal.Location = new System.Drawing.Point(671, 186);
            this.lblSubTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.Size = new System.Drawing.Size(17, 18);
            this.lblSubTotal.TabIndex = 8;
            this.lblSubTotal.Text = "0";
            // 
            // btnCreateOrder
            // 
            this.btnCreateOrder.BackColor = System.Drawing.Color.LightGreen;
            this.btnCreateOrder.Location = new System.Drawing.Point(627, 289);
            this.btnCreateOrder.Margin = new System.Windows.Forms.Padding(4);
            this.btnCreateOrder.Name = "btnCreateOrder";
            this.btnCreateOrder.Size = new System.Drawing.Size(120, 37);
            this.btnCreateOrder.TabIndex = 7;
            this.btnCreateOrder.Text = "Tạo Order";
            this.btnCreateOrder.UseVisualStyleBackColor = false;
            this.btnCreateOrder.Click += new System.EventHandler(this.btnCreateOrder_Click);
            // 
            // lblTax
            // 
            this.lblTax.AutoSize = true;
            this.lblTax.Location = new System.Drawing.Point(570, 137);
            this.lblTax.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTax.Name = "lblTax";
            this.lblTax.Size = new System.Drawing.Size(56, 16);
            this.lblTax.TabIndex = 6;
            this.lblTax.Text = "Thuế %:";
            // 
            // txtTax
            // 
            this.txtTax.Location = new System.Drawing.Point(673, 137);
            this.txtTax.Margin = new System.Windows.Forms.Padding(4);
            this.txtTax.Name = "txtTax";
            this.txtTax.Size = new System.Drawing.Size(65, 22);
            this.txtTax.TabIndex = 5;
            this.txtTax.Text = "0";
            this.txtTax.TextChanged += new System.EventHandler(this.txtTax_TextChanged);
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Location = new System.Drawing.Point(570, 94);
            this.lblDiscount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(79, 16);
            this.lblDiscount.TabIndex = 4;
            this.lblDiscount.Text = "Giảm giá %:";
            // 
            // txtDiscount
            // 
            this.txtDiscount.Location = new System.Drawing.Point(673, 91);
            this.txtDiscount.Margin = new System.Windows.Forms.Padding(4);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(65, 22);
            this.txtDiscount.TabIndex = 3;
            this.txtDiscount.Text = "0";
            this.txtDiscount.TextChanged += new System.EventHandler(this.txtDiscount_TextChanged);
            // 
            // lblCurrentTable
            // 
            this.lblCurrentTable.AutoSize = true;
            this.lblCurrentTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblCurrentTable.Location = new System.Drawing.Point(13, 31);
            this.lblCurrentTable.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCurrentTable.Name = "lblCurrentTable";
            this.lblCurrentTable.Size = new System.Drawing.Size(68, 20);
            this.lblCurrentTable.TabIndex = 1;
            this.lblCurrentTable.Text = "Bàn: --";
            // 
            // grpFoods
            // 
            this.grpFoods.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpFoods.Controls.Add(this.btnAddFood);
            this.grpFoods.Controls.Add(this.lblQuantity);
            this.grpFoods.Controls.Add(this.nudQuantity);
            this.grpFoods.Controls.Add(this.lblCategory);
            this.grpFoods.Controls.Add(this.cboCategory);
            this.grpFoods.Controls.Add(this.lblSearchFood);
            this.grpFoods.Controls.Add(this.txtSearchFood);
            this.grpFoods.Controls.Add(this.dgvFoods);
            this.grpFoods.Location = new System.Drawing.Point(16, 15);
            this.grpFoods.Margin = new System.Windows.Forms.Padding(4);
            this.grpFoods.Name = "grpFoods";
            this.grpFoods.Padding = new System.Windows.Forms.Padding(4);
            this.grpFoods.Size = new System.Drawing.Size(1568, 357);
            this.grpFoods.TabIndex = 0;
            this.grpFoods.TabStop = false;
            this.grpFoods.Text = "Danh sách món ăn";
            // 
            // btnAddFood
            // 
            this.btnAddFood.BackColor = System.Drawing.Color.LightBlue;
            this.btnAddFood.Location = new System.Drawing.Point(1398, 25);
            this.btnAddFood.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddFood.Name = "btnAddFood";
            this.btnAddFood.Size = new System.Drawing.Size(149, 37);
            this.btnAddFood.TabIndex = 7;
            this.btnAddFood.Text = "Thêm vào Order";
            this.btnAddFood.UseVisualStyleBackColor = false;
            this.btnAddFood.Click += new System.EventHandler(this.btnAddFood_Click);
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(1200, 34);
            this.lblQuantity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(63, 16);
            this.lblQuantity.TabIndex = 6;
            this.lblQuantity.Text = "Số lượng:";
            // 
            // nudQuantity
            // 
            this.nudQuantity.Location = new System.Drawing.Point(1280, 31);
            this.nudQuantity.Margin = new System.Windows.Forms.Padding(4);
            this.nudQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudQuantity.Name = "nudQuantity";
            this.nudQuantity.Size = new System.Drawing.Size(67, 22);
            this.nudQuantity.TabIndex = 5;
            this.nudQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(667, 34);
            this.lblCategory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(70, 16);
            this.lblCategory.TabIndex = 4;
            this.lblCategory.Text = "Danh mục:";
            // 
            // cboCategory
            // 
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Location = new System.Drawing.Point(753, 31);
            this.cboCategory.Margin = new System.Windows.Forms.Padding(4);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(265, 24);
            this.cboCategory.TabIndex = 3;
            this.cboCategory.SelectedIndexChanged += new System.EventHandler(this.cboCategory_SelectedIndexChanged);
            // 
            // lblSearchFood
            // 
            this.lblSearchFood.AutoSize = true;
            this.lblSearchFood.Location = new System.Drawing.Point(13, 34);
            this.lblSearchFood.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSearchFood.Name = "lblSearchFood";
            this.lblSearchFood.Size = new System.Drawing.Size(62, 16);
            this.lblSearchFood.TabIndex = 2;
            this.lblSearchFood.Text = "Tìm món:";
            // 
            // txtSearchFood
            // 
            this.txtSearchFood.Location = new System.Drawing.Point(93, 31);
            this.txtSearchFood.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearchFood.Name = "txtSearchFood";
            this.txtSearchFood.Size = new System.Drawing.Size(399, 22);
            this.txtSearchFood.TabIndex = 1;
            this.txtSearchFood.TextChanged += new System.EventHandler(this.txtSearchFood_TextChanged);
            // 
            // dgvFoods
            // 
            this.dgvFoods.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFoods.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFoods.Location = new System.Drawing.Point(13, 74);
            this.dgvFoods.Margin = new System.Windows.Forms.Padding(4);
            this.dgvFoods.Name = "dgvFoods";
            this.dgvFoods.RowHeadersWidth = 51;
            this.dgvFoods.Size = new System.Drawing.Size(1533, 275);
            this.dgvFoods.TabIndex = 0;
            this.dgvFoods.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFoods_CellContentClick);
            // 
            // tsmiQLTK
            // 
            this.tsmiQLTK.Name = "tsmiQLTK";
            this.tsmiQLTK.Size = new System.Drawing.Size(224, 26);
            this.tsmiQLTK.Text = "Quản lý tài khoản";
            this.tsmiQLTK.Click += new System.EventHandler(this.quảnLýTàiKhoảnToolStripMenuItem_Click);
            // 
            // tsmiQLHD
            // 
            this.tsmiQLHD.Name = "tsmiQLHD";
            this.tsmiQLHD.Size = new System.Drawing.Size(224, 26);
            this.tsmiQLHD.Text = "Quản lý hóa đơn";
            this.tsmiQLHD.Click += new System.EventHandler(this.quảnLýHóaĐơnToolStripMenuItem_Click);
            // 
            // tsmiQLLM
            // 
            this.tsmiQLLM.Name = "tsmiQLLM";
            this.tsmiQLLM.Size = new System.Drawing.Size(224, 26);
            this.tsmiQLLM.Text = "Quản lý loại món";
            this.tsmiQLLM.Click += new System.EventHandler(this.quảnLýLoạiMónToolStripMenuItem_Click);
            // 
            // tsmiQLM
            // 
            this.tsmiQLM.Name = "tsmiQLM";
            this.tsmiQLM.Size = new System.Drawing.Size(224, 26);
            this.tsmiQLM.Text = "Quản lý món";
            this.tsmiQLM.Click += new System.EventHandler(this.quảnLýMónToolStripMenuItem_Click);
            // 
            // tsmiQLBan
            // 
            this.tsmiQLBan.Name = "tsmiQLBan";
            this.tsmiQLBan.Size = new System.Drawing.Size(224, 26);
            this.tsmiQLBan.Text = "Quản lý bàn";
            this.tsmiQLBan.Click += new System.EventHandler(this.quảnLýBànToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 814);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống quản lý nhà hàng - Restaurant Management System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.grpTables.ResumeLayout(false);
            this.grpOrder.ResumeLayout(false);
            this.grpOrder.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderDetails)).EndInit();
            this.grpFoods.ResumeLayout(false);
            this.grpFoods.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFoods)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private GroupBox groupBox1;
        private DataGridView dgvOrderDetails;
        private ToolStripMenuItem tsmiQLTK;
        private ToolStripMenuItem tsmiQLHD;
        private ToolStripMenuItem tsmiQLLM;
        private ToolStripMenuItem tsmiQLM;
        private ToolStripMenuItem tsmiQLBan;
    }
}

