namespace StichtitePizzaForm
{
    using System;

    public class FilePermissionDeniedException : ApplicationException
    {
        public FilePermissionDeniedException(string msg)
            : base(msg)
        {
        }

        public FilePermissionDeniedException(string msg, Exception innerEx)
            : base(msg, innerEx)
        {
        }
    }
}