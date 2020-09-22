using System.Runtime.Remoting.Channels;
using Pims.Core.CommonModel;

namespace Pims.Core.Model.OperationModules
{
    public class FamilyInfortation : BaseDomain
    {
        public int Id { get; set; }
        public int GeneralInformationId { get; set; }
        public GeneralInformation GeneralInformation { get; set; }
        public string Name { get; set; }
        public string Relation { get; set; }
        public string PhoneNo { get; set; }
        public string MaritalStatus { get; set; }
        public string Occupation { get; set; }

    }
}