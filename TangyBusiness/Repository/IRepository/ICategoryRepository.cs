using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TangyModels;

namespace TangyBusiness.Repository.IRepository
{
    public interface ICategoryRepository
    {
        public CategoryDTO Create(CategoryDTO objDTO);
        public CategoryDTO Update(CategoryDTO objDTO);
        public int Delete(int Id);
        public CategoryDTO Get(int Id);
        public IEnumerable<CategoryDTO> GetAll();

    }
}
