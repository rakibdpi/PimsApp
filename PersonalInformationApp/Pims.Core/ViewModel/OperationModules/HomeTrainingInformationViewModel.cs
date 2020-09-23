using Pims.Core.Model;
using Pims.Core.Model.OperationModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pims.Core.ViewModel.OperationModules
{
   public class HomeTrainingInformationViewModel 
    {
        public int Id { get; set; }
        public int GeneralInformationId { get; set; }
        public GeneralInformation GeneralInformation { get; set; }
        public string NameEnglish { get; set; }
        public string PhoneNo { get; set; }
        public string CourseName { get; set; }
        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }
        public string Duration { get; set; }
        public string Result { get; set; }
        public string Address { get; set; }
    }
}
