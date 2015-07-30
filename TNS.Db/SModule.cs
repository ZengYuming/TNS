using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TNS.Db
{

    /// <summary>
    /// 模块定义信息
    /// Author:
    /// Date:
    /// </summary>
    /// 
    [Serializable]
    public class SModule //: BaseEntity
    {
        public virtual string ModuleId    { get; set; }
        public virtual string ParentId   { get; set; }
        public virtual string Platform   { get; set; }
        public virtual string ModuleName { get; set; }
        public virtual string FullName    { get; set; }
        public virtual string ShortName  { get; set; }
        public virtual string ActionName { get; set; }
        public virtual string ModuleType { get; set; }
        public virtual string LinkUrl     { get; set; }
        public virtual int    OrderNo    { get; set; }
        public virtual string Icon     { get; set; }
    }
}
