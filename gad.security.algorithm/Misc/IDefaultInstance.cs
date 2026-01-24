using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gad.security.algorithm.Misc
{
    public interface IDefaultInstance<T>
    {
        static abstract T DefaultInstance { get; }
    }
}
