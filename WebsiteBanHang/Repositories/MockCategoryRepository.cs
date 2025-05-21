using WebsiteBanHang.Models;

namespace WebsiteBanHang.Repositories
{
    public class MockCategoryRepository : ICategoryRepository
    {
        private List<Category> _categoryList;
        public MockCategoryRepository()
        {
            _categoryList = new List<Category>
        {
         new Category { Id = 1, Name = "Laptop" },
         new Category { Id = 2, Name = "Điện Thoại" },
         // Thêm các category khác

           };
        }
        public IEnumerable<Category> GetAllCategories()
        {
            return _categoryList;
        }

        public Category GetById(int id)
        {
            return _categoryList.FirstOrDefault((p => p.Id == id));
        }

        public void Add(Category category)
        {
            category.Id = _categoryList.Max(p => p.Id) + 1;
            _categoryList.Add(category);
        }

        public void Update(Category category)
        {
            var index = _categoryList.FindIndex(p => p.Id == category.Id);
            if (index != -1)
            {
                _categoryList[index] = category;
            }
        }

        public void Delete(int id)
        {
            var category = _categoryList.FirstOrDefault(p => p.Id == id);
            if (category != null)
            {
                _categoryList.Remove(category);
            }
        }
    }
}
