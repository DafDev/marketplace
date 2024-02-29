﻿using FluentAssertions;

namespace Marketplace.Tests;
public class ClassifiedAdTitleTests
{
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void GivenNullOrWhitespaceTitleWhenInstanciationShouldTrhowArgumentNullExcpetion(string? title)
    {
        //When
        var action = () => ClassifiedAdTitle.FromString(title);
        //Should
        action.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void GivenTitleMoreThan100CharWhenInstanciationShouldTrhowArgumentExcpetion()
    {
        //Given
        var title = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque rutrum, tellus et posuere tincidunt.";
        //When
        var action = () => ClassifiedAdTitle.FromString(title);
        //Should
        action.Should().Throw<ArgumentException>().WithMessage("Title is bigger than a 100 characters.");
    }

    [Fact]
    public void GivenHtmlTitleWhenInstanciationShouldReturn()
    {
        //Given
        var title = "<b>Lorem</b> <i>ipsum</i> dolor sit amet";
        var expected = ClassifiedAdTitle.FromString("**Lorem** *ipsum* dolor sit amet");
        //When
        var actual = ClassifiedAdTitle.FromHtml(title);
        //Should
        actual.Should().Be(expected);
    }
}
