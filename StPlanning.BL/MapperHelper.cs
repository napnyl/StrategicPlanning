using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StPlanning.BL
{
    public static class MapperHelper
    {
        public static void Register<TSource, TDestination>()
        {
            var mapped = Mapper.FindTypeMapFor(typeof(TSource), typeof(TDestination));
            if (mapped == null)
            {
                var expression = Mapper.CreateMap<TSource, TDestination>();
            }
        }
        public static TDestination QuickMap<TSource, TDestination>(this TSource source)
        {
            return Mapper.Map<TSource, TDestination>(source);
        }
    }
}
