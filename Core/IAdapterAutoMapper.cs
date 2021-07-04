using System.Collections.Generic;

namespace app.api.Core
{
    public interface IAdapterAutoMapper
    {
        TTarget CreateMap<TTarget>(object source) where TTarget : class, new();
    }
}