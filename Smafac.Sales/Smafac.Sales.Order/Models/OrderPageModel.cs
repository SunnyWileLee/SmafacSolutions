using Smafac.Framework.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.Order.Models
{
    public class OrderPageModel : PageModel<OrderModel>
    {
        public OrderPageModel(PageModel<OrderModel> page)
        {
            this.PageData = page.PageData;
            this.PageIndex = page.PageIndex;
            this.PageSize = page.PageSize;
            this.TableColumns = page.TableColumns;
            this.TotalCount = page.TotalCount;
        }

        public OrderPageModel(OrderPageQueryModel query)
            : base(query)
        {
            ChargeTableColumns = new List<CustomizedColumnModel>();
        }

        public List<CustomizedColumnModel> ChargeTableColumns { get; set; }
    }
}
