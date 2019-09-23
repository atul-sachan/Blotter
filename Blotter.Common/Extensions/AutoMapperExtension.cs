using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blotter.Common.Extensions
{
    public static class AutoMapperExtension
    {
        public static D MapTo<S, D>(this IMapper mapper, S value)
        {
            return mapper.Map<S,D>(value);
        }

        public static IEnumerable<D> EnumerableTo<S, D>(this IMapper mapper, IEnumerable<S> value)
        {
            return mapper.Map<IEnumerable<S>,IEnumerable<D>>(value);
        }


    }
}
