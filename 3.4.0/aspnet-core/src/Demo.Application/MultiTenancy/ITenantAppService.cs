using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Demo.MultiTenancy.Dto;

namespace Demo.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
