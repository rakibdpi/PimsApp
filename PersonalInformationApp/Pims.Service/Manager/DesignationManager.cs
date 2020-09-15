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
    public class DesignationManager
    {
        private PimsDbContext _dbContext;

        public DesignationManager()
        {
            _dbContext = new PimsDbContext();
        }

        public DesignationViewModel Get(int id)
        {
            var entity = _dbContext.Designations.SingleOrDefault(c => c.Id == id);
            return (Mapper.Map<Designation, DesignationViewModel>(entity));
        }

        public IEnumerable<DesignationViewModel> GetAll()
        {
            var entities = _dbContext.Designations.ToList().
                Select(Mapper.Map<Designation, DesignationViewModel>);
            return entities;
        }

        public int Add(DesignationViewModel vm)
        {
            var entity = Mapper.Map<DesignationViewModel, Designation>(vm);
            _dbContext.Designations.Add(entity);
            var isSave = _dbContext.SaveChanges();
            return isSave;
        }

        public int Update(int id, DesignationViewModel vm)
        {
            var entity = _dbContext.Designations.SingleOrDefault(c => c.Id == id);
            Mapper.Map(vm, entity);
            var isUpdate = _dbContext.SaveChanges();
            return isUpdate;
        }

        public int Remove(int id)
        {
            var entity = _dbContext.Designations.SingleOrDefault(c => c.Id == id);
            _dbContext.Designations.Remove(entity);
            var isDelete = _dbContext.SaveChanges();
            return isDelete;
        }
    }
}
