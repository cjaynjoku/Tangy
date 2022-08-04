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
        public Task<CategoryDTO> Create(CategoryDTO objDTO);
        public Task<CategoryDTO> Update(CategoryDTO objDTO);
        public Task<int> Delete(int Id);
        public Task<CategoryDTO> Get(int Id);
        public Task<IEnumerable<CategoryDTO>> GetAll();
            
    }
}
