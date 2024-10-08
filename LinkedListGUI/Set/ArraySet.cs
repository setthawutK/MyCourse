using Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Set
{
    public class ArraySet : ArrayCollection, Set
    {
        public ArraySet(int cap) : base(cap) { }
        public void add(object e)
        {
            if (!base.contains(e)) base.add(e);
        }

    }
}
