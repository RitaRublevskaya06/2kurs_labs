using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interf
{
    public interface ICollectionOperations<T>
    {
        void Add(T item);
        void Remove(T item);
        T View(int index);
    }
}
