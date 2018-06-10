using MediaStorage.Common;
using MediaStorage.Common.ViewModels.Category;
using MediaStorage.Data;
using MediaStorage.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MediaStorage.Service
{
    public interface ICategoryService
    {
        ICollection<CategoryListViewModel> GetAllCategories();

        ICollection<CustomSelectListItem> GetSubCategoriesAsSelectListItem(int? id);

        CategoryViewModel GetCategoryById(int id);

        ServiceResult AddCategory(CategoryViewModel entity);

        ServiceResult UpdateCategory(CategoryViewModel entity);

        ServiceResult RemoveCategory(int id, bool cascadeRemove = false);
    }

    public class CategoryService : ICategoryService
    {
        private IUnitOfWork uow;
        private IRepository<Category> categoryRepository;

        public CategoryService(IUnitOfWork uow, IRepository<Category> categoryRepository)
        {
            this.uow = uow;
            this.categoryRepository = categoryRepository;
        }

        public ICollection<CategoryListViewModel> GetAllCategories()
        {
            return categoryRepository
                .GetAll(i => i.MaterialType)
                .Select(s => new CategoryListViewModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    ParentCategory = s.ParentCategory.Name,
                    MaterialType = s.MaterialType.Name
                }).ToList();
        }

        public ICollection<CustomSelectListItem> GetSubCategoriesAsSelectListItem(int? id)
        {
            return categoryRepository
                .GetAll()
                .Select(s => new CustomSelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.Name,
                    Selected = id.HasValue
                        ? s.SubCategories.Any(w => w.Id == id)
                        : false
                }).ToList();
        }

        public CategoryViewModel GetCategoryById(int id)
        {
            var category = categoryRepository.Find(id);

            return category == null ? null : new CategoryViewModel
            {
                 Id = category.Id,
                 Name = category.Name,
                 ParentCategoryId = category.ParentCategoryId,
                 MaterialTypeId = category.MaterialTypeId
            };
        }

        public ServiceResult AddCategory(CategoryViewModel entity)
        {
            categoryRepository.Add(new Category
            {
                Name = entity.Name,
                ParentCategoryId = entity.ParentCategoryId,
                MaterialTypeId = entity.MaterialTypeId
            });

            return ServiceResult.GetAddResult(uow.Commit() == 1);
        }

        public ServiceResult UpdateCategory(CategoryViewModel entity)
        {
            categoryRepository.Update(new Category
            {
                Id = entity.Id.Value,
                Name = entity.Name,
                ParentCategoryId = entity.ParentCategoryId,
                MaterialTypeId = entity.MaterialTypeId
            });

            return ServiceResult.GetUpdateResult(uow.Commit() == 1);
        }

        public ServiceResult RemoveCategory(int id, bool cascadeRemove = false)
        {
            if(cascadeRemove)
            {
                // TODO: Cascade remove
            }

            categoryRepository.Delete(id);

            return ServiceResult.GetRemoveResult(uow.Commit() > 0);
        }
    }
}
