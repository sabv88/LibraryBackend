namespace LibraryApplication.Common.Exceptions
{
    public class AlredyExistException : Exception
    {
        public AlredyExistException(string name, object key) : base($"Entity \"{name}\" ({key}) with same fields alredy exist.") { }
    }
}
