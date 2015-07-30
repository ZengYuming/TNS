using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TNS.Metadata
{
    public class Menu
    {
        public virtual int menuid { get; set; }
        public virtual string menuname { get; set; }
        public virtual string url { get; set; }
        public virtual string icon { get; set; }
        public virtual List<Menu> menus { get; set; } 
    }
}
