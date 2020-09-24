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
   public class SocialMediaManager
    {
        private PimsDbContext _dbContext;

        public SocialMediaManager()
        {
            _dbContext = new PimsDbContext();
        }

        public SocialMediaViewModel Get(int id)
        {
            var department = _dbContext.SocialMedias.SingleOrDefault(c => c.Id == id);
            return (Mapper.Map<SocialMedia, SocialMediaViewModel>(department));
        }

        public IEnumerable<SocialMediaViewModel> GetAll()
        {
            var entity = _dbContext.SocialMedias.ToList().Where(c => c.IsDelete == false)
                .Select(Mapper.Map<SocialMedia, SocialMediaViewModel>);
            return entity;
        }


        public int Add(SocialMediaViewModel vm)
        {
            var entity = Mapper.Map<SocialMediaViewModel, SocialMedia>(vm);
            entity.CreateBy = "User";
            entity.CreateDate = DateTime.Now;
            entity.IsDelete = false;
            _dbContext.SocialMedias.Add(entity);
            _dbContext.SaveChanges();
            return entity.GeneralInformationId;
        }

        public int Update(int id, SocialMediaViewModel vm)
        {
            var entity = _dbContext.SocialMedias.SingleOrDefault(c => c.Id == id);
            Mapper.Map(vm, entity);
            entity.UpdateBy = "User";
            entity.UpdateDate = DateTime.Now;
            _dbContext.SaveChanges();
            return entity.GeneralInformationId;
        }

        public int Remove(int id)
        {
            var entity = _dbContext.SocialMedias.SingleOrDefault(c => c.Id == id);
            entity.DeleteBy = "User";
            entity.DeleteDate = DateTime.Now;
            entity.IsDelete = true;
            var isUpdate = _dbContext.SaveChanges();
            return isUpdate;
        }
    }
}
