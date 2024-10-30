namespace SimpleTrader.Domain.Exceptions
{
    public class InvalidSymbolException : Exception
    {
        public string Symbol { get; set; }

        public InvalidSymbolException(string symbol)
        {
            Symbol = symbol;
        }

        public InvalidSymbolException(string? message, string symbol) : base(message)
        {
            Symbol = symbol;
        }

        public InvalidSymbolException(string? message, string symbol, Exception? innerException) : base(message, innerException)
        {
            Symbol = symbol;
        }
    }
}
