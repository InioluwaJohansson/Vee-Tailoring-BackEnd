using V_Tailoring.Context;
using V_Tailoring.Interfaces.Respositories;
using V_Tailoring.Emails;
using V_Tailoring.Interface.Services;

namespace V_Tailoring
{
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
}
