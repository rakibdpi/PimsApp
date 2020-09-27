using Pims.Core.Model.OperationModules;
using System.ComponentModel.DataAnnotations;

namespace Pims.Core.ViewModel.OperationModules
{
    public class EmergencyContactViewModel
    {
        public int Id { get; set; }
        public int GeneralInformationId { get; set; }
        public GeneralInformation GeneralInformation { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Relation { get; set; }
        [Required]
        public string PhoneNo { get; set; }
        [Required]
        public string Address { get; set; }
        public string Email { get; set; }

        public string Phone { get; set; }

        public string NameEnglish { get; set; }

    }
}