using System.ComponentModel;

namespace OnlineShop.Domain.Enums;

public enum DiscountType
{
    [Description("Percentage")]
    Percentage,

    [Description("Flat Price")]
    FlatPrice
}
