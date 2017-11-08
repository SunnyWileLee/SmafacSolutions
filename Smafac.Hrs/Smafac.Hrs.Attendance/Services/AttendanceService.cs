using Smafac.Hrs.Attendance.Applications;
using Smafac.Hrs.Attendance.Models;
using Smafac.Hrs.Attendance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Smafac.Hrs.Attendance.Domain;
using Smafac.Framework.Core.Models;
using Smafac.Hrs.Attendance.Repositories.PropertyValue;

namespace Smafac.Hrs.Attendance.Services
{
    class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceAddRepository _goodsRepository;
        private readonly IAttendancePropertyValueSetRepository _propertyValueSetRepository;

        public AttendanceService(IAttendanceAddRepository goodsRepository,
                            IAttendanceUpdateService updateService,
                            IAttendancePropertyValueSetRepository propertyValueSetRepository
                            )
        {
            _goodsRepository = goodsRepository;
            _propertyValueSetRepository = propertyValueSetRepository;
            UpdateService = updateService;
        }

        public IAttendanceUpdateService UpdateService { get; set; }

        public bool AddAttendance(AttendanceModel model)
        {
            var goods = Mapper.Map<AttendanceEntity>(model);
            goods.SubscriberId = UserContext.Current.SubscriberId;
            var add = _goodsRepository.AddEntity(goods);

            if (add && model.HasProperties)
            {
                model.Properties.ForEach(property =>
                {
                    property.AttendanceId = goods.Id;
                    property.SubscriberId = goods.SubscriberId;
                });
                var values = Mapper.Map<List<AttendancePropertyValueEntity>>(model.Properties);
                return _propertyValueSetRepository.AddPropertyValues(goods.Id, values);
            }
            return add;
        }

        public AttendanceModel CreateEmptyAttendance()
        {
            return new AttendanceModel();
        }
    }
}
