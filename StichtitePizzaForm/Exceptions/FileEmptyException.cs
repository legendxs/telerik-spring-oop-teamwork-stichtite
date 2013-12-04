namespace StichtitePizzaForm
{
    using System;

    public class FileEmptyException : ApplicationException
    {
        public FileEmptyException(string msg)
            : base(msg)
        {
        }

        public FileEmptyException(string msg, Exception innerEx)
            : base(msg, innerEx)
        {
        }
    }
}