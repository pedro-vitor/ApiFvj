using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiFvj.Data.Converter
{
    public interface IParse<O, D>
    {
        D Parse(O origin);
        List<D> Parse(List<O> origin);
    }
}
