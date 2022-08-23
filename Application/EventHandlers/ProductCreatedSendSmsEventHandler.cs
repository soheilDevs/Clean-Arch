using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Domain.ProductAgg.Events;
using MediatR;

namespace Application.EventHandlers
{
    internal class ProductCreatedSendSmsEventHandler : INotificationHandler<ProductCreated>
    {
        private readonly ISmsService _smsService;

        public ProductCreatedSendSmsEventHandler(ISmsService smsService)
        {
            _smsService = smsService;
        }
        public async Task Handle(ProductCreated notification, CancellationToken cancellationToken)
        {
            _smsService.SendSms(new SmsBody());
            await Task.CompletedTask;
        }
    }
}
