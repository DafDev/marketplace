namespace Marketplace.Domain.Shared.Exceptions;
public class ProfanityFoundException(string text) : Exception($"Profanity found in text: {text}") { }
