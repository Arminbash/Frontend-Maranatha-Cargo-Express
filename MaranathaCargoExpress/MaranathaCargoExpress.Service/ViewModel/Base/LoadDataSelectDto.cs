using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaranathaCargoExpress.Service.ViewModel.Base
{
    public class LoadDataSelectDto<T>
    {
        public int total_count { get; set; }
        public bool incomplete_results { get; set; }
        public List<T> items { get; set; }
        
    }
}
