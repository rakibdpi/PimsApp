using Pims.Core.CommonModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pims.Core.Model.OperationModules
{
    public class GeneralInformation : BaseDomain
    {
        public int Id { get; set; }
        [Required]

        public string EmployeId { get; set; }
        [Required]

        public string NameBangla { get; set; }
        [Required]


        public string NameEnglish { get; set; }

        public string FatherName { get; set; }

        public string MotherName { get; set; }
        [Required]

        public DateTime BithDate { get; set; }

        public string BirthPlace { get; set; }

        public string Nationality { get; set; }

        public string PresentAddress { get; set; }

        public string PermanentAddress { get; set; }

        public string BloodGroup { get; set; }

        public string Religion { get; set; }

        public string Gender { get; set; }

        public string MeritialStatus { get; set; }
        [Required]

        public string PhoneNo { get; set; }

        public string Email { get; set; }
        [Required]

        public string NationalId { get; set; }

        public int DepartmentId { get; set; }

        public Department Department { get; set; }

        public int DesignationId { get; set; }

        public Designation Designation { get; set; }

        public string Position { get; set; }
        [Required]

        public DateTime JobJoiningDate { get; set; }
    }
}
