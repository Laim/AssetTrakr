namespace AssetTrakr.Utils.Exceptions
{
    public class UpdateUrlEmptyException : Exception
    {
        public UpdateUrlEmptyException() : base("Update URL cannot be empty.") { }

        public UpdateUrlEmptyException(string message) : base(message) { }

        public UpdateUrlEmptyException(string message, Exception inner) : base(message, inner) { }
    }
}
