using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    // Lớp CategoryBL có các phương thức xử lý bảng Category
    public class CategoryBL
    {
        // Đối tượng CategoryDA từ DataAccess
        CategoryDA categoryDA = new CategoryDA();

        // Phương thức lấy hết dữ liệu
        public List<Category> GetAll()
        {
            return categoryDA.GetAll();
        }

        // Phương thức thêm dữ liệu
        public int Insert(Category category)
        {
            ValidateCategory(category);
            return categoryDA.Insert_Update_Delete(category, 0);
        }

        // Phương thức cập nhật dữ liệu
        public int Update(Category category)
        {
            ValidateCategory(category);
            return categoryDA.Insert_Update_Delete(category, 1);
        }

        // Phương thức xoá dữ liệu truyền vào ID
        public int Delete(Category category)
        {
            return categoryDA.Insert_Update_Delete(category, 2);
        }

        // PHƯƠNG THỨC TÌM KIẾM MỚI - BỔ SUNG
        public List<Category> Find(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return GetAll();

            return categoryDA.Find(keyword);
        }

        // Phương thức validate dữ liệu
        private void ValidateCategory(Category category)
        {
            if (string.IsNullOrEmpty(category.Name))
                throw new Exception("Tên danh mục không được để trống");

            if (category.Name.Length > 200)
                throw new Exception("Tên danh mục không được vượt quá 200 ký tự");
        }

        // Phương thức lấy Category theo ID
        public Category GetByID(int id)
        {
            var allCategories = GetAll();
            return allCategories.FirstOrDefault(c => c.ID == id);
        }
    }
}