using Vee_Tailoring.Context;
using Vee_Tailoring.Interfaces.Respositories;
using Vee_Tailoring.Emails;
using Vee_Tailoring.Interface.Services;

namespace Vee_Tailoring;

public class VBackgroundService : BackgroundService
{
    IServiceScopeFactory _serviceScopeFactory;
    public VBackgroundService(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }
    protected async override Task ExecuteAsync(CancellationToken token)
    {
        using var vscope = _serviceScopeFactory.CreateScope();
        var context = vscope.ServiceProvider.GetRequiredService<TailoringContext>();
        await Task.CompletedTask;
    }
}
