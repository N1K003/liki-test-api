using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Liki.BusinessLogic.Contracts.Models.DeliveryWindow;
using Liki.BusinessLogic.Contracts.Services;
using Liki.BusinessLogic.Extensions;
using Liki.Common.Exceptions;
using Liki.Data.Contracts.Abstractions;
using Liki.Data.Contracts.Models;
using Microsoft.EntityFrameworkCore;

namespace Liki.BusinessLogic.Services
{
    public class DeliveryWindowService : IDeliveryWindowService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeliveryWindowService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<DeliveryWindowRule>> GetDeliveryWindowRulesAsync(CancellationToken cancellationToken)
        {
            var rules = await _unitOfWork.Get<DbDeliveryWindow>()
                .ToListAsync(cancellationToken);

            return rules.Select(x => x.ToBlModel());
        }

        public async Task<IEnumerable<DeliveryWindowModel>> GetDeliveryWindowsAsync(DateTimeOffset fromDate, int horizon,
            CancellationToken cancellationToken)
        {
            var rules = await _unitOfWork.Get<DbDeliveryWindow>()
                .ToListAsync(cancellationToken);

            return GetAvailableWindows(fromDate, horizon, rules).OrderBy(x => x.Start);
        }

        public async Task CreateDeliveryWindowAsync(CreateDeliveryWindowModel model, CancellationToken cancellationToken)
        {
            _unitOfWork.Create(new DbDeliveryWindow
            {
                Name = model.Name,
                Description = model.Description,
                AvailableByHoursBefore = model.AvailableByHoursBefore,
                Start = model.Start,
                End = model.End,
                Price = model.Price,
                IsAvailable = model.IsAvailable,
                WindowType = (int) model.WindowType
            });

            await _unitOfWork.CommitAsync(cancellationToken);
        }

        public async Task UpdateDeliveryWindowAsync(int windowId, UpdateDeliveryWindowModel model, CancellationToken cancellationToken)
        {
            var dbWindow = await _unitOfWork.Get<DbDeliveryWindow>()
                .FirstOrDefaultAsync(x => x.Id == windowId, cancellationToken);

            if (dbWindow == null)
            {
                throw new NotFoundException("window");
            }

            dbWindow.Name = model.Name;
            dbWindow.Description = model.Description;
            dbWindow.AvailableByHoursBefore = model.AvailableByHoursBefore;
            dbWindow.Start = model.Start;
            dbWindow.End = model.End;
            dbWindow.Price = model.Price;
            dbWindow.IsAvailable = model.IsAvailable;
            dbWindow.WindowType = (int) model.WindowType;

            await _unitOfWork.CommitAsync(cancellationToken);
        }

        private static IEnumerable<DeliveryWindowModel> GetAvailableWindows(DateTimeOffset fromDate, int horizon,
            IReadOnlyCollection<DbDeliveryWindow> rules)
        {
            var result = new List<DeliveryWindowModel>();
            for (var i = 0; i <= horizon; i++)
            {
                if (i == 0)
                {
                    result.AddRange(rules
                        .Where(x => fromDate.Date.Add(x.Start - x.AvailableByHoursBefore) > fromDate)
                        .Select(x => x.ToBlModel(fromDate)));
                }
                else
                {
                    result.AddRange(rules.Select(x => x.ToBlModel(fromDate)));
                }
            }

            return result;
        }
    }
}