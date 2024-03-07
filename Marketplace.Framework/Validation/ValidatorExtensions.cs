using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Marketplace.Framework.Validation;
public static class ValidatorExtensions
{
    public static PropertyValidatorBuilder<string> LengthBetween(this PropertyValidatorBuilder<string> value, int min, int max)
    {
        if (value.Property.Length < min) value.Add(new ArgumentOutOfRangeException(value.PropertyName, $"Can't have less than {min} items"));
        if (value.Property.Length > max) value.Add(new ArgumentOutOfRangeException(value.PropertyName, $"Can't have more than {max} items"));
        return value;
    }

    public static PropertyValidatorBuilder<P> NotNull<P>(this PropertyValidatorBuilder<P> value)
    {
        if (value.Property == null
            || typeof(P) == typeof(string) && string.IsNullOrWhiteSpace(value.Property?.ToString()))
            value.Add(new ArgumentNullException(value.PropertyName));

        return value;
    }

    public static PropertyValidatorBuilder<string> IsHex(this PropertyValidatorBuilder<string> value)
    {
        if (string.IsNullOrEmpty(value.Property)) throw new ArgumentOutOfRangeException(value.PropertyName, "Hex String Empty");
        for (int i = 0; i < value.Property.Length; i++)
        {
            if (!char.IsDigit(value.Property.ToCharArray()[i]))
            {
                if (value.Property.ToCharArray()[i] < 'A' && value.Property.ToCharArray()[i] > 'F')
                    value.Add(new ArgumentOutOfRangeException(value.PropertyName, "Invalid Hex Character: " + value.Property.ToCharArray()[i]));
            }
        }
        return value;
    }

    public static PropertyValidatorBuilder<string> NotWhiteSpace(this PropertyValidatorBuilder<string> value)
    {
        if (string.IsNullOrWhiteSpace(value.Property)) throw new ArgumentNullException(value.PropertyName);
        return value;
    }

    public static PropertyValidatorBuilder<P> RangeWithin<P>(this PropertyValidatorBuilder<P> value, P min, P max) where P : IComparable<P>
    {
        if (value.Property.CompareTo(min) < 0) value.Add(new ArgumentOutOfRangeException(value.PropertyName, $"Can't have less than {min} items"));
        if (value.Property.CompareTo(max) > 0) value.Add(new ArgumentOutOfRangeException(value.PropertyName, $"Can't have more than {max} items"));
        return value;
    }

    public static PropertyValidatorBuilder<P> NotLessThan<P>(this PropertyValidatorBuilder<P> value, P min) where P : IComparable<P>
    {
        if (value.Property.CompareTo(min) < 0) value.Add(new ArgumentOutOfRangeException(value.PropertyName, $"Can't have less than {min} items"));
        return value;
    }

    public static PropertyValidatorBuilder<P> NotGreaterThan<P>(this PropertyValidatorBuilder<P> value, P max) where P : IComparable<P>
    {
        if (value.Property.CompareTo(max) > 0) value.Add(new ArgumentOutOfRangeException(value.PropertyName, $"Can't have more than {max} items"));
        return value;
    }
}
