using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Pims.Core.Model.OperationModules;
using Pims.Core.ViewModel.OperationModules;
using Pims.Persistense.DatabaseFile;

namespace Pims.Service.Manager.OperationModules
{
    public class GeneralInformationManager
    {
        private PimsDbContext _dbContext;

        public GeneralInformationManager()
        {
            _dbContext = new PimsDbContext();
        }

        public GeneralInformationViewModel Get(int id)
        {
            var department = _dbContext.GeneralInformations.SingleOrDefault(c => c.Id == id);
            return (Mapper.Map<GeneralInformation, GeneralInformationViewModel>(department));
        }

        public IEnumerable<GeneralInformationViewModel> GetAll()
        {
            var entity = _dbContext.GeneralInformations.ToList().Where(c => c.IsDelete == false)
                .Select(Mapper.Map<GeneralInformation, GeneralInformationViewModel>);
          
            return entity;
        }


        public int Add(GeneralInformationViewModel vm)
        {
            var entity = Mapper.Map<GeneralInformationViewModel, GeneralInformation>(vm);
            entity.CreateBy = "User";
            entity.CreateDate = DateTime.Now;
            entity.IsDelete = false;
            _dbContext.GeneralInformations.Add(entity);
            _dbContext.SaveChanges();
            return entity.Id;
        }

        public int Update(int id, GeneralInformationViewModel vm)
        {
            var entity = _dbContext.GeneralInformations.SingleOrDefault(c => c.Id == id);
            Mapper.Map(vm, entity);
            entity.UpdateBy = "User";
            entity.UpdateDate = DateTime.Now;
            _dbContext.SaveChanges();
            return entity.Id;
        }

        public int Remove(int id)
        {
            var entity = _dbContext.GeneralInformations.SingleOrDefault(c => c.Id == id);
            entity.DeleteBy = "User";
            entity.DeleteDate = DateTime.Now;
            entity.IsDelete = true;
            var isUpdate = _dbContext.SaveChanges();
            return isUpdate;
        }

        public string GenerateEmployeId()
        {
            int parsonalNo = 0;

            var list = _dbContext.GeneralInformations.ToList()
                .OrderByDescending(c => c.Id).FirstOrDefault();

            if (list == null)
            {
                var code = "NSSL-" + "000001";
                return code;
            }

            {
                string[] parts = list.EmployeId.Split('-');
                parsonalNo = Convert.ToInt32(parts[1]);
            }

            var traineeParsonalNo = "NSSL-" + (parsonalNo + 1).ToString().PadLeft(5, '0');
            return traineeParsonalNo;

        }





    }
}
