using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TangyBusiness.Repository.IRepository;
using TangyDataAccess;
using TangyDataAccess.Data;
using TangyModels;

namespace TangyBusiness.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDBContext _db;

        private readonly IMapper _mapper;

        public CategoryRepository(ApplicationDBContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

      public async Task<CategoryDTO> Create(CategoryDTO objDTO)
        {
            var obj = _mapper.Map<CategoryDTO, Category>(objDTO);
            obj.CreatedDate = DateTime.Now;
           var addObj = _db.Categories.Add(obj);
            await _db.SaveChangesAsync();
            return _mapper.Map<Category, CategoryDTO>(addObj.Entity);
        }

        public async Task<int> Delete(int Id)
        {
            var obj = _db.Categories.FirstOrDefaultAsync(o => o.Id == Id);
            if(obj != null)
            {
                _db.Categories.Remove(obj);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<CategoryDTO> Get(int Id)
        {
            var obj = _db.Categories.FirstOrDefaultAsync(o => o.Id == Id);
            if (obj != null)
            {
                var _obj = _mapper.Map<Category, CategoryDTO>(obj);
                return _obj;
            }
            return default;
           
        }

        public async Task<IEnumerable<CategoryDTO>> GetAll()
        {
            var allCategory = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(_db.Categories);
            return allCategory;
        }

        public async Task<CategoryDTO> Update(CategoryDTO objDTO)
        {
            var objFromDB = await _db.Categories.FirstOrDefaultAsync(o => o.Id == objDTO.Id);
            if (objFromDB != null)
            {
                objFromDB.Name = objDTO.Name;
                _db.Categories.Update(objFromDB);
                await _db.SaveChangesAsync();
;                var _obj = _mapper.Map<Category, CategoryDTO>(objFromDB);
                return _obj;
            }
            return objDTO;
        }
    }
}
