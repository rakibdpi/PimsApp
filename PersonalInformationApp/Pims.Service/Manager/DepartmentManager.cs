using AutoMapper;
using Pims.Core.Model;
using Pims.Core.ViewModel;
using Pims.Persistense.DatabaseFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pims.Service.Manager
{
    public class DepartmentManager
    {
        private PimsDbContext _dbContext;

        public DepartmentManager()
        {
            _dbContext = new PimsDbContext();
        }

        public DepartmentViewModel Get(int id)
        {
            var department = _dbContext.Departments.SingleOrDefault(c => c.Id == id);
            return (Mapper.Map<Department, DepartmentViewModel>(department));
        }

        public IEnumerable<DepartmentViewModel> GetAll()
        {
            var department = _dbContext.Departments.ToList().
                Select(Mapper.Map<Department, DepartmentViewModel>);
            return department;
        }

        public int Add(DepartmentViewModel vm)
        {
            var entity = Mapper.Map<DepartmentViewModel, Department>(vm);
            _dbContext.Departments.Add(entity);
            var isSave = _dbContext.SaveChanges();
            return isSave;
        }

        public int Update(int id,DepartmentViewModel vm)
        {
            var entity = _dbContext.Departments.SingleOrDefault(c => c.Id == id);
            Mapper.Map(vm, entity);
            var isUpdate = _dbContext.SaveChanges();
            return isUpdate;
        }

        public int Remove(int id)
        {
            var entity = _dbContext.Departments.SingleOrDefault(c => c.Id == id);
            _dbContext.Departments.Remove(entity);
            var isDelete = _dbContext.SaveChanges();
            return isDelete;
        }

    }
}
