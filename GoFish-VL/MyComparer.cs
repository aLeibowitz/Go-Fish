using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFish_VL
{
    class MyComparer: IComparer
    {
        int IComparer.Compare(Object xx, Object yy)
        {
            Cards card1 = (Cards)xx;
            Cards card2 = (Cards)yy;
            return card1._rank.CompareTo(card2._rank);
        }
    }
}
