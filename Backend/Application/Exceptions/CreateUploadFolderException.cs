using System;

namespace Application.Exceptions;
public class CreateUploadFolderException : Exception
{
    public CreateUploadFolderException()
    : base()
    {
    }

    public CreateUploadFolderException(string message)
        : base(message)
    {
    }

    public CreateUploadFolderException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

}