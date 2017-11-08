﻿using Smafac.Framework.Core.Domain;
using Smafac.Framework.Core.Domain.EntityAssociationProviders;
using Smafac.Framework.Core.Models;
using Smafac.Hrs.Attendance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Hrs.Attendance.Domain.CategoryProperty
{
    interface IAttendanceCategoryPropertyProvider:IEntityAssociationProvider<AttendancePropertyModel>
    {
        
    }
}
