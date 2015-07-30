using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TNS.MVC4.Common;
using Framework.Core.Model;
using Framework.Core.Extensions;

namespace TNS.MVC4.Controllers
{
    public class PagingController : BaseController// AuthorizedController
    {
        /// <summary>
        /// 每页显示的条数
        /// </summary>
        public int PageSize
        {
            get
            {
                var defaultPageSize = ConfigHelper.DefaultPageSize;
                return Request.Form["rows"] != null ?
                    Request.Form["rows"].ConvertToInteger(defaultPageSize) : defaultPageSize; ;
            }
        }
        /// <summary>
        /// 当前显示的页号
        /// </summary>
        public int PageIndex
        {
            get
            {
                return Request.Form["page"] != null ? Request.Form["page"].ConvertToInteger(1) : 1;
            }
        }

        /// <summary>
        /// 排序关键字
        /// </summary>
        public virtual string OrderField
        {
            get
            {
                return Request.Form["sort"] ?? "CreateTime";
            }
        }

        public virtual OrderEnum Order
        {
            get
            {
                return Request.Form["order"] != null ?
                (OrderEnum)Enum.Parse(typeof(OrderEnum), Request.Form["order"])
                : OrderEnum.desc;
            }
        }

        protected PageInfo Pager;

        public virtual PageInfo BuildPageInfo()
        {
            return new PageInfo
            {
                PageIndex = PageIndex,
                PageSize = PageSize,
                OrderField = OrderField,
                Order = Order
            };
        }

    }
}
