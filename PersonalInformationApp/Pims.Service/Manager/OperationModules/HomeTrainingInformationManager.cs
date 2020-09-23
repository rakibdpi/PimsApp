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
   public class HomeTrainingInformationManager
    {
        private PimsDbContext _dbContext;

        public HomeTrainingInformationManager()
        {
            _dbContext = new PimsDbContext();
        }

        public HomeTrainingInformationViewModel Get(int id)
        {
            var department = _dbContext.HomeTrainingInformations.SingleOrDefault(c => c.Id == id);
            return (Mapper.Map<HomeTrainingInformation, HomeTrainingInformationViewModel>(department));
        }

        public IEnumerable<HomeTrainingInformationViewModel> GetAll()
        {
            var entity = _dbContext.HomeTrainingInformations.ToList().Where(c => c.IsDelete == false)
                .Select(Mapper.Map<HomeTrainingInformation, HomeTrainingInformationViewModel>);
            return entity;
        }


        public int Add(HomeTrainingInformationViewModel vm)
        {
            var entity = Mapper.Map<HomeTrainingInformationViewModel, HomeTrainingInformation>(vm);
            entity.CreateBy = "User";
            entity.CreateDate = DateTime.Now;
            entity.IsDelete = false;
            _dbContext.HomeTrainingInformations.Add(entity);
            _dbContext.SaveChanges();
            return entity.GeneralInformationId;
        }

        public int Update(int id, HomeTrainingInformationViewModel vm)
        {
            var entity = _dbContext.HomeTrainingInformations.SingleOrDefault(c => c.Id == id);
            Mapper.Map(vm, entity);
            entity.UpdateBy = "User";
            entity.UpdateDate = DateTime.Now;
            _dbContext.SaveChanges();
            return entity.GeneralInformationId;
        }

        public int Remove(int id)
        {
            var entity = _dbContext.HomeTrainingInformations.SingleOrDefault(c => c.Id == id);
            entity.DeleteBy = "User";
            entity.DeleteDate = DateTime.Now;
            entity.IsDelete = true;
            var isUpdate = _dbContext.SaveChanges();
            return isUpdate;
        }

    }
}
