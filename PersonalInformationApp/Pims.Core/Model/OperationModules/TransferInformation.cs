using Pims.Core.CommonModel;

namespace Pims.Core.Model.OperationModules
{
    public class TransferInformation : BaseDomain
    {
        public int Id { get; set; }
        public int GeneralInformationId { get; set; }
        public GeneralInformation GeneralInformation { get; set; }

        public string WorkingPlace { get; set; }
        public string Duration { get; set; }
        public string OfficeOrderNumber { get; set; }
        public string Address { get; set; }
        public string Remarks { get; set; }
    }
}