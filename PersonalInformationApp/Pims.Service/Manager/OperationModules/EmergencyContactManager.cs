using AutoMapper;
using Pims.Core.Model.OperationModules;
using Pims.Core.ViewModel.OperationModules;
using Pims.Persistense.DatabaseFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Pims.Service.Manager.OperationModules
{
    public class EmergencyContactManager
    {
        private PimsDbContext _dbContext;

        public EmergencyContactManager()
        {
            _dbContext = new PimsDbContext();
        }

        public EmergencyContactViewModel Get(int id)
        {
            var entities = _dbContext.EmergencyContact.SingleOrDefault(c => c.Id == id);
            return (Mapper.Map<EmergencyContact, EmergencyContactViewModel>(entities));
        }

        public IEnumerable<EmergencyContactViewModel> GetAll()
        {

            var entity = _dbContext.EmergencyContact.ToList().Where(c => c.IsDelete == false)
            .Select(Mapper.Map<EmergencyContact, EmergencyContactViewModel>);
            return entity;

        }
        public int Add(EmergencyContactViewModel vm)
        {
            var entity = Mapper.Map<EmergencyContactViewModel, EmergencyContact>(vm);
            entity.CreateBy = "User";
            entity.CreateDate = DateTime.Now;
            entity.IsDelete = false;
            _dbContext.EmergencyContact.Add(entity);
            _dbContext.SaveChanges();
            return entity.GeneralInformationId;
        }

        public int Update(int id, EmergencyContactViewModel vm)
        {
            var entity = _dbContext.EmergencyContact.SingleOrDefault(c => c.Id == id);
            Mapper.Map(vm, entity);
            entity.UpdateBy = "User";
            entity.UpdateDate = DateTime.Now;
            _dbContext.SaveChanges();
            return entity.GeneralInformationId;
        }

        public int Remove(int id)
        {
            var entity = _dbContext.EmergencyContact.SingleOrDefault(c => c.Id == id);
            entity.DeleteBy = "User";
            entity.DeleteDate = DateTime.Now;
            entity.IsDelete = true;
            var isUpdate = _dbContext.SaveChanges();
            return isUpdate;
        }

    }
}
