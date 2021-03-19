using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Versioning
{
    public interface MovieInterface<T>
    {
        List<T> getMovieList();
        T getList();
    }
}
