
namespace LibraryApplication.Common.Exceptions
{
    public class AlredyTakenException : Exception
    {
        public AlredyTakenException(object bookKey, object userKey)
            : base($"Book ({bookKey}) is alredy taken by user ({userKey}).") { }
    }
}
