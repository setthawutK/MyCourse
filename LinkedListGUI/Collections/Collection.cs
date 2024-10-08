using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    public interface Collection
    {
        void add(object e);
        void remove(object e);
        bool isEmpty();
        bool contains(object e);
        int size();
        
    }
}
