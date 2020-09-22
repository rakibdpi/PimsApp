using Pims.Core.CommonModel;

namespace Pims.Core.Model.OperationModules
{
    public class HomeTrainingInformation : BaseDomain
    {
        public int Id { get; set; }
        public int GeneralInformationId { get; set; }
        public GeneralInformation GeneralInformation { get; set; }
        public string CourseName { get; set; }
        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }
        public string Duration { get; set; }
        public string Result { get; set; }
        public string Address { get; set; }
    }
}