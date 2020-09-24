using Pims.Core.Model.OperationModules;
using Pims.Core.Model.SetupModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pims.Core.ViewModel.OperationModules
{
  public  class EducationInformationsViewModel
    {

        public int Id { get; set; }

        public int GeneralInformationId { get; set; }
        public GeneralInformation GeneralInformation { get; set; }
        public string ExamName { get; set; }
        public University University { get; set; }
        public int UniversityId { get; set; }
        public string Subject { get; set; }
        public string Year { get; set; }
        public string Result { get; set; }
        public string SchoolOrCallege { get; set; }
        public string PhoneNo { get; set; }

        public string NameEnglish { get; set; }

    }
}
