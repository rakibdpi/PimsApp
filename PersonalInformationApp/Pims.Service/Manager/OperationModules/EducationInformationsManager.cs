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
    public class EducationInformationsManager
    {

        private PimsDbContext _dbContext;

        public EducationInformationsManager()
        {
            _dbContext = new PimsDbContext();
        }

        public EducationInformationsViewModel Get(int id)
        {
            var entitys = _dbContext.EducationsInformations.SingleOrDefault(c => c.Id == id);
            return (Mapper.Map<EducationInformations, EducationInformationsViewModel>(entitys));
        }

        public IEnumerable<EducationInformationsViewModel> GetAll()
        {
            var entity = _dbContext.EducationsInformations.ToList().Where(c => c.IsDelete == false)
                .Select(Mapper.Map<EducationInformations, EducationInformationsViewModel>);
            return entity;
        }
        public int Add(EducationInformationsViewModel vm)
        {
            var entity = Mapper.Map<EducationInformationsViewModel, EducationInformations>(vm);
            entity.CreateBy = "User";
            entity.CreateDate = DateTime.Now;
            entity.IsDelete = false;
            _dbContext.EducationsInformations.Add(entity);
            _dbContext.SaveChanges();
            return entity.GeneralInformationId;
        }

        public int Update(int id, EducationInformationsViewModel vm)
        {
            var entity = _dbContext.EducationsInformations.SingleOrDefault(c => c.Id == id);
            Mapper.Map(vm, entity);
            entity.UpdateBy = "User";
            entity.UpdateDate = DateTime.Now;
            _dbContext.SaveChanges();
            return entity.GeneralInformationId;
        }

        public int Remove(int id)
        {
            var entity = _dbContext.EducationsInformations.SingleOrDefault(c => c.Id == id);
            entity.DeleteBy = "User";
            entity.DeleteDate = DateTime.Now;
            entity.IsDelete = true;
            var isUpdate = _dbContext.SaveChanges();
            return isUpdate;
        }


    }
}
