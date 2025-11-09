using BusinessLogic;
using DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;


namespace RestaurantManagementProject
{
    public partial class frmFood : Form
    {
        List<Category> listCategory = new List<Category>();  // Danh sách danh mục
        List<Food> listFood = new List<Food>();             // Danh sách thực phẩm
        Food foodCurrent = new Food();                      // Thực phẩm đang chọn
        public frmFood()
        {
            InitializeComponent();
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdClear_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtPrice.Text = "0";
            txtUnit.Text = "";
            txtNotes.Text = "";

            if (cbbCategory.Items.Count > 0)
                cbbCategory.SelectedIndex = 0;  // Reset về item đầu tiên
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            int result = InsertFood();
            if (result > 0)
            {
                MessageBox.Show("Thêm dữ liệu thành công");
                LoadFoodDataToListView(); // Refresh ListView
            }
            else
                MessageBox.Show("Thêm dữ liệu không thành công. Vui lòng kiểm tra lại dữ liệu nhập");
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            int result = UpdateFood();
            if (result > 0)
            {
                MessageBox.Show("Cập nhật dữ liệu thành công");
                LoadFoodDataToListView(); // Refresh ListView
            }
            else
                MessageBox.Show("Cập nhật dữ liệu không thành công. Vui lòng kiểm tra lại dữ liệu nhập");
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            // Xác nhận trước khi xóa
            if (MessageBox.Show("Bạn có chắc chắn muốn xoá mẫu tin này?", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                FoodBL foodBL = new FoodBL();
                if (foodBL.Delete(foodCurrent) > 0) // Xóa thành công
                {
                    MessageBox.Show("Xoá thực phẩm thành công");
                    LoadFoodDataToListView(); // Refresh ListView
                }
                else
                    MessageBox.Show("Xoá không thành công");
            }
        }

        private void frmFood_Load(object sender, EventArgs e)
        {
            LoadCategory();                 // Nạp danh mục vào ComboBox
            LoadFoodDataToListView();       // Nạp thực phẩm vào ListView
        }
        private void LoadCategory()
        {
            CategoryBL categoryBL = new CategoryBL();
            listCategory = categoryBL.GetAll();             // Lấy dữ liệu từ Business Logic
            cbbCategory.DataSource = listCategory;          // Gán vào ComboBox
            cbbCategory.ValueMember = "ID";
            cbbCategory.DisplayMember = "Name";
        }

        public void LoadFoodDataToListView()
        {
            FoodBL foodBL = new FoodBL();
            listFood = foodBL.GetAll();
            int count = 1;
            lsvFood.Items.Clear();

            foreach (var food in listFood)
            {
                ListViewItem item = lsvFood.Items.Add(count.ToString());
                item.SubItems.Add(food.Name);
                item.SubItems.Add(food.Unit);
                item.SubItems.Add(food.Price.ToString());

                // Tìm tên danh mục theo ID
                string categoryName = listCategory.Find(x => x.ID == food.FoodCategoryID).Name;
                item.SubItems.Add(categoryName);
                item.SubItems.Add(food.Notes);
                count++;
            }
        }

        private void lsvFood_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public int InsertFood()
        {
            Food food = new Food();
            food.ID = 0;

            // Kiểm tra dữ liệu nhập
            if (txtName.Text == "" || txtUnit.Text == "" || txtPrice.Text == "")
            {
                MessageBox.Show("Chưa nhập dữ liệu cho các ô, vui lòng nhập lại");
                return -1;
            }
            else
            {
                // Nhận dữ liệu từ form
                food.Name = txtName.Text;
                food.Unit = txtUnit.Text;
                food.Notes = txtNotes.Text;

                // Xử lý giá (có bắt lỗi)
                int price = 0;
                try
                {
                    price = int.Parse(txtPrice.Text);
                }
                catch
                {
                    price = 0;
                }
                food.Price = price;

                // Lấy CategoryID từ ComboBox
                food.FoodCategoryID = int.Parse(cbbCategory.SelectedValue.ToString());

                // Gọi Business Logic để chèn dữ liệu
                FoodBL foodBL = new FoodBL();
                return foodBL.Insert(food);
            }
        }

        public int UpdateFood()
        {
            // Lấy đối tượng hiện hành
            Food food = foodCurrent;

            // Kiểm tra dữ liệu nhập
            if (txtName.Text == "" || txtUnit.Text == "" || txtPrice.Text == "")
            {
                MessageBox.Show("Chưa nhập dữ liệu cho các ô, vui lòng nhập lại");
                return -1;
            }
            else
            {
                // Cập nhật dữ liệu từ form
                food.Name = txtName.Text;
                food.Unit = txtUnit.Text;
                food.Notes = txtNotes.Text;

                // Xử lý giá (có bắt lỗi)
                int price = 0;
                try
                {
                    price = int.Parse(txtPrice.Text);
                }
                catch
                {
                    price = 0;
                }
                food.Price = price;

                // Lấy CategoryID từ ComboBox
                food.FoodCategoryID = int.Parse(cbbCategory.SelectedValue.ToString());

                // Gọi Business Logic để cập nhật
                FoodBL foodBL = new FoodBL();
                return foodBL.Update(food);
            }
        }

        private void lsvFood_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lsvFood.Items.Count; i++)
            {
                if (lsvFood.Items[i].Selected)
                {
                    foodCurrent = listFood[i];                          // Lấy thực phẩm được chọn
                    txtName.Text = foodCurrent.Name;                    // Hiển thị tên
                    txtUnit.Text = foodCurrent.Unit;                    // Hiển thị đơn vị
                    txtPrice.Text = foodCurrent.Price.ToString();       // Hiển thị giá
                    txtNotes.Text = foodCurrent.Notes;                  // Hiển thị ghi chú

                    // Chọn đúng danh mục trong ComboBox
                    cbbCategory.SelectedIndex = listCategory.FindIndex(x => x.ID == foodCurrent.FoodCategoryID);
                }
            }
        }
    }
}
