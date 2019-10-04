using System.Collections.Generic;

namespace ApiFvj.Data.Converter
{
    public interface IParser<O, D>
     {
            D Parse(O origin);
            List<D> Parse(List<O> origin);
     }
    
}
