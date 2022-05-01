using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchPictures.Model
{
    class PagingHelper
    {
        private readonly int myItemsPerPage = 20;
        private readonly int myItemsCount;
        private int myCurrentPageIndex;

        public int CurrentPage => myCurrentPageIndex + 1;

        private int CalculateTotalPages()
        {
            return myItemsCount % myItemsPerPage == 0 ? myItemsCount / myItemsPerPage : (myItemsCount / myItemsPerPage) + 1;
        }
    }
}
