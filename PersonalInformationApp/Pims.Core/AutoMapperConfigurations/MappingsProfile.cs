using AutoMapper;
using Pims.Core.CommonModel;
using Pims.Core.Model;
using Pims.Core.Model.OperationModules;
using Pims.Core.ViewModel;
using Pims.Core.ViewModel.OperationModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pims.Core.AutoMapperConfigurations
{
    public class MappingsProfile : Profile
    {
        public override string ProfileName => "MappingsProfile";

        public MappingsProfile()
        {
            CreateMap<Department, DepartmentViewModel>();
            CreateMap<DepartmentViewModel, Department>();

            CreateMap<Designation, DesignationViewModel>();
            CreateMap<DesignationViewModel, Designation>();

            CreateMap<Organization, OrganizationViewModel>();
            CreateMap<OrganizationViewModel, Organization>();


            CreateMap<GeneralInformation, GeneralInformationViewModel>()
                .ForMember(vm => vm.BithDate,
                    opt => opt.MapFrom(m => DateTimeFormater.DateToString(m.BithDate)))
                .ForMember(dto => dto.JobJoiningDate,
                    opt => opt.MapFrom(m => DateTimeFormater.DateToString(m.JobJoiningDate)));

            CreateMap<GeneralInformationViewModel, GeneralInformation>()
                .ForMember(dto => dto.BithDate,
                    opt => opt.MapFrom(m => DateTimeFormater.StringToDate(m.BithDate)))
                .ForMember(dto => dto.JobJoiningDate,
                    opt => opt.MapFrom(m => DateTimeFormater.StringToDate(m.JobJoiningDate)));

            CreateMap<EducationInformations, EducationInformationsViewModel>();
            CreateMap<EducationInformationsViewModel, EducationInformations>();
              

            CreateMap<HomeTrainingInformation, HomeTrainingInformationViewModel>();
            CreateMap<HomeTrainingInformationViewModel, HomeTrainingInformation>();

            CreateMap<SocialMedia, SocialMediaViewModel>();
            CreateMap<SocialMediaViewModel, SocialMedia>();


            CreateMap<EmergencyContact, EmergencyContactViewModel>();
            CreateMap<EmergencyContactViewModel, EmergencyContact>();

        }
    }
}
