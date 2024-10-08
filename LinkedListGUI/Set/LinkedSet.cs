using Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Set
{
    public class LinkedSet : LinkedHeaderCollection , Set
    {
        private void add(object e)
        {
            if (!base.contains(e)) base.add(e);
        }
    }
}
