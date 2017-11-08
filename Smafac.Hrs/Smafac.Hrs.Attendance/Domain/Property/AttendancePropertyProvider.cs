using Smafac.Framework.Core.Models;
using Smafac.Hrs.Attendance.Domain.CategoryProperty;
using Smafac.Hrs.Attendance.Models;
using Smafac.Hrs.Attendance.Repositories;
using System;
using System.Collections.Generic;

namespace Smafac.Hrs.Attendance.Domain.Property
{
    class AttendancePropertyProvider : IAttendancePropertyProvider
    {
        private readonly IAttendanceSearchRepository _searchRepository;
        private readonly IAttendanceCategoryPropertyProvider _categoryPropertyProvider;

        public AttendancePropertyProvider(IAttendanceSearchRepository searchRepository,
                                    IAttendanceCategoryPropertyProvider categoryPropertyProvider
                                    )
        {
            _searchRepository = searchRepository;
            _categoryPropertyProvider = categoryPropertyProvider;
        }

        public List<AttendancePropertyModel> Provide(Guid goodsId)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            var goods = _searchRepository.GetAttendance(subscriberId, goodsId);
            return _categoryPropertyProvider.ProvideAssociations(goods.CategoryId);
        }
    }
}
