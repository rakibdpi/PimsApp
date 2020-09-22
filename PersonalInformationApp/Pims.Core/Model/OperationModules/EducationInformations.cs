using Pims.Core.CommonModel;
using Pims.Core.Model.SetupModules;

namespace Pims.Core.Model.OperationModules
{
    public class EducationInformations : BaseDomain
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
    }
}