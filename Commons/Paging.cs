using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons
{
    public class Paging
    {

        int pageSize = 20;
        public int? Pages { get; set; }

        public int? PageSize
        {
            get => pageSize;
            set
            {
                if (value != null) pageSize = (int)value;
            }
        }
    }
}
