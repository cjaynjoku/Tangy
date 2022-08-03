using AutoMapper;
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

      public CategoryDTO Create(CategoryDTO objDTO)
        {
            var obj = _mapper.Map<CategoryDTO, Category>(objDTO);
            obj.CreatedDate = DateTime.Now;
           var addObj = _db.Categories.Add(obj);
            _db.SaveChanges();
            return _mapper.Map<Category, CategoryDTO>(addObj.Entity);
        }

        public int Delete(int Id)
        {
            var obj = _db.Categories.FirstOrDefault(o => o.Id == Id);
            if(obj != null)
            {
                _db.Categories.Remove(obj);
                return _db.SaveChanges();
            }
            return 0;
        }

        public CategoryDTO Get(int Id)
        {
            var obj = _db.Categories.FirstOrDefault(o => o.Id == Id);
            if (obj != null)
            {
                var _obj = _mapper.Map<Category, CategoryDTO>(obj);
                return _obj;
            }
            return default;
           
        }

        public IEnumerable<CategoryDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(_db.Categories);
        }

        public CategoryDTO Update(CategoryDTO objDTO)
        {
            var objFromDB = _db.Categories.FirstOrDefault(o => o.Id == objDTO.Id);
            if (objFromDB != null)
            {
                objFromDB.Name = objDTO.Name;
                _db.Categories.Update(objFromDB);
                _db.SaveChanges();
;                var _obj = _mapper.Map<Category, CategoryDTO>(objFromDB);
                return _obj;
            }
            return objDTO;
        }
    }
}
