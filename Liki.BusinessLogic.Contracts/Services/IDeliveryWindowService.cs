using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Liki.BusinessLogic.Contracts.Models.DeliveryWindow;

namespace Liki.BusinessLogic.Contracts.Services
{
    public interface IDeliveryWindowService
    {
        Task<IEnumerable<DeliveryWindowRule>> GetDeliveryWindowRulesAsync(CancellationToken cancellationToken);

        Task<IEnumerable<DeliveryWindowModel>> GetDeliveryWindowsAsync(DateTimeOffset fromDate, int horizon,
            CancellationToken cancellationToken);

        Task CreateDeliveryWindowAsync(CreateDeliveryWindowModel model, CancellationToken cancellationToken);
        Task UpdateDeliveryWindowAsync(int windowId, UpdateDeliveryWindowModel model, CancellationToken cancellationToken);
    }
}