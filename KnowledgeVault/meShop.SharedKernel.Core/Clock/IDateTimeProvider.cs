namespace meShop.SharedKernel.Core.Clock;
public interface IDateTimeProvider
{
    public DateTime UtcNow { get; }
}