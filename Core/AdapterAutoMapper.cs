using System.Collections.Generic;
using AutoMapper;

namespace app.api.Core
{
    public class AdapterAutoMapper : IAdapterAutoMapper
    {
        private readonly IMapper _mapper;
        public AdapterAutoMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public TTarget CreateMap<TTarget>(object source) where TTarget : class, new()
        {
            return _mapper.Map<TTarget>(source);
        }

    }
}