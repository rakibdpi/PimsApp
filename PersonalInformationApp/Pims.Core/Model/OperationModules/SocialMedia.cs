﻿using Pims.Core.CommonModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pims.Core.Model.OperationModules
{
    public class SocialMedia : BaseDomain
    {
        public int Id { get; set; }
        public int GeneralInformationId { get; set; }
        public GeneralInformation GeneralInformation { get; set; }
        public string MediaName { get; set; }
        public string MediaLink { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
