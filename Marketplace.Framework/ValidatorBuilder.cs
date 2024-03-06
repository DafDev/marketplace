using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace Marketplace.Framework;

public class ValidatorBuilder
{
    protected List<Exception> _exceptions;
    
    public ValidatorBuilder() => _exceptions = [];
    public ValidatorBuilder(List<Exception> exceptions) => _exceptions = exceptions;

    public PropertyValidatorBuilder<T> For<T>(T property, [CallerArgumentExpression(nameof(property))] string? propertyName = default)
    {
        return new(_exceptions, property, propertyName);
    }
    public ValidatorBuilder NotNull<T>(T property, [CallerArgumentExpression(nameof(property))] string? propertyName = default)
    {
        if (property == null)
            _exceptions.Add(new ArgumentNullException(propertyName));
        return this;
    }
    public ValidatorBuilder LengthBetween(string property, int min, int max, [CallerArgumentExpression(nameof(property))] string? propertyName = default)
    {
        if (property.Length < min) _exceptions.Add(new ArgumentOutOfRangeException(propertyName, $"Can't have less than {min} items"));
        if (property.Length > max) _exceptions.Add(new ArgumentOutOfRangeException(propertyName, $"Can't have more than {max} items"));
        return this;
    }
    public ValidatorBuilder RangeWithin<P>(P property, P min, P max, [CallerArgumentExpression(nameof(property))] string? propertyName = default) where P : IComparable
    {
        if (property.CompareTo(min) < 0) _exceptions.Add(new ArgumentOutOfRangeException(propertyName, $"Can't have less than {min} items"));
        if (property.CompareTo(max) > 0) _exceptions.Add(new ArgumentOutOfRangeException(propertyName, $"Can't have more than {max} items"));
        return this;
    }
    public ValidatorBuilder LessThan<P>(P property, P min, [CallerArgumentExpression(nameof(property))] string? propertyName = default) where P : IComparable<P>
    {
        if (property.CompareTo(min) < 0) _exceptions.Add(new ArgumentOutOfRangeException(propertyName, $"Can't have less than {min} items"));
        return this;
    }

    public ValidatorBuilder GreaterThan<P>(P property, P max, [CallerArgumentExpression(nameof(property))] string? propertyName = default) where P : IComparable<P>
    {
        if (property.CompareTo(max) > 0) _exceptions.Add(new ArgumentOutOfRangeException(propertyName, $"Can't have more than {max} items"));
        return this;
    }
    public ValidatorBuilder IsOneOf<P>(P property, IEnumerable<P> options, [CallerArgumentExpression(nameof(property))] string? propertyName = default)
    {
        if (!options.Contains(property)) _exceptions.Add(new ArgumentOutOfRangeException(propertyName, $"Is not a valid option"));
        return this;
    }
    public ValidatorBuilder IsHex(string property, [CallerArgumentExpression(nameof(property))] string? propertyName = default)
    {
        if (string.IsNullOrEmpty(property)) throw new ArgumentOutOfRangeException(propertyName, "Hex String Empty");
        for (int i = 0; i < property.Length; i++)
        {
            if (!char.IsDigit(property.ToCharArray()[i]))
            {
                if ((property.ToCharArray()[i] < 'A') && (property.ToCharArray()[i] > 'F'))
                    _exceptions.Add(new ArgumentOutOfRangeException(propertyName, "Invalid Hex Character: " + property.ToCharArray()[i]));
            }
        }
        return this;
    }
    public bool IsValid(bool shouldThrowException = true)
    {
        return _exceptions.Count == 0 ||
            (!shouldThrowException ? false : throw new AggregateException(_exceptions));
    }
}
