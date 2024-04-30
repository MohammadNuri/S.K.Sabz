using S.K.Sabz.Application.Services.Blog.Queries.GetAllCategories;

namespace S.K.Sabz.Application.Services.Blog.Queries.GetCategories
{
    public class CategoriesDto 
    {
        public List<AllCategoriesDto> AllCategories { get; set; }
        public long Id { get; set; }   
        public string Name { get; set; } = string.Empty;    
        public bool HasChild { get; set; }
        public ParentCategoryDto Parent { get; set; }

    } 
}
