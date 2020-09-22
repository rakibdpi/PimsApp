namespace Pims.Core.Model.OperationModules
{
    public class EmergencyContact
    {
        public int Id { get; set; }
        public int GeneralInformationId { get; set; }
        public GeneralInformation GeneralInformation { get; set; }
        public string Name { get; set; }
        public string Relation { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
    }
}