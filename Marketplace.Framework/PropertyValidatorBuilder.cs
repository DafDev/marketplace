using System.Runtime.CompilerServices;

namespace Marketplace.Framework;
public class PropertyValidatorBuilder<T> : ValidatorBuilder
{
    internal string? PropertyName { get; init; }
    internal T Property { get; init; }
    public PropertyValidatorBuilder(T property, [CallerArgumentExpression(nameof(property))] string? propertyName = default) : base()
    {
        Property = property;
        PropertyName = propertyName;
    }
    // For creation from other ValidatorBuilder or other PropertyValidatorBuilder
    public PropertyValidatorBuilder(List<Exception> exceptions, T property, string? propertyName) : base(exceptions)
    {
        Property = property;
        PropertyName = propertyName;
    }
    public PropertyValidatorBuilder<P> AndFor<P>(P property, [CallerArgumentExpression(nameof(property))] string? propertyName = default) => new(_exceptions, property, propertyName);
    public PropertyValidatorBuilder<T> NotNull()
    {
        if (Property == null)
            _exceptions.Add(new ArgumentNullException(PropertyName));
        return this;
    }
    public PropertyValidatorBuilder<T> IsOneOf(IEnumerable<T> options)
    {
        if (!options.Contains(Property)) _exceptions.Add(new ArgumentOutOfRangeException(PropertyName, $"Is not a valid option"));
        return this;
    }

    internal void Add(ArgumentOutOfRangeException argumentOutOfRangeException)
    {
        _exceptions.Add(argumentOutOfRangeException);
    }
}

