namespace ProiectV1.Helpers.Exceptions
{

    [Serializable]
    public class NoProductsFoundException : Exception
    {
        public NoProductsFoundException(string? message) : base(message)
        { 
        }

        public NoProductsFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
