using meShop.SharedKernel.Core.Clock;

namespace meShop.SharedKernel.Infrastructure.Clock;
internal sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}