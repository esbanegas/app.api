using System.Collections.Generic;
using app.api.DataContext.BaseEntities;
using AutoMapper;

namespace app.api.Core
{
    public static class ProjectionsExtensionMethods
    {
        private static IAdapterAutoMapper _adapterAutoMapper;

        public static void Configure(IMapper mapper){
            _adapterAutoMapper = new AdapterAutoMapper(mapper);
        }
        public static List<TProjection> ProjectedAsCollection<TProjection>(this IEnumerable<Entity> items)
            where TProjection : class, new()
        {
            return _adapterAutoMapper.CreateMap<List<TProjection>>(items);
        }

        public static TProjection ProjectedAsItem<TProjection>(this Entity entity)
            where TProjection : class, new()
        {
            return _adapterAutoMapper.CreateMap<TProjection>(entity);
        }
    }
}