using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 졸업작품
{
    class toppingclass
    {
        private string 메뉴2;
        private int 가격2;
        public string 메뉴
        {
            get
            {
                return 메뉴2;
            }
            set
            {
                메뉴2 = value;
            }
        }
        public int 가격
        {
            get
            {
                return 가격2;
            }
            set
            {
                가격2 = value;
            }
        }
        public toppingclass(string d, int p)
        {
            메뉴2 = d;
            가격2 = p;
        }
    }
}
