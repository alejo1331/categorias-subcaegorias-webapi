using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Categorias.Application.Models
{
    public class PaginateModel
    {
        public PaginateModel()
        {
            searchFilter = "";
            ordenActual = "";
            pageNumber = 0;
            pageSize = 10;
            pageSizeList = new List<int>{
                5,
                10,
                20,
                50,
                100
            };
        }

        public string searchFilter { get; set; }
        public string searchField { get; set; }
        public string orden { get; set; }
        public string ordenActual { get; set; }
        public List<string> fieldList { get; set; }
        public int pageNumber { get; set; }
        public int pageSize { get; set; }
        public List<int> pageSizeList { get; set; }
        public string ColumnValue { get; set; }
        public string ColumnFilter { get; set; }
        public Boolean Descending { get; set; }
    }
}
