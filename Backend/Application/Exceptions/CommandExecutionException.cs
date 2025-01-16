using System;
using System.Collections.Generic;

namespace Application.Exceptions;

public class CommandExecutionException : Exception
{
    public List<string> Errors = new();
    public CommandExecutionException()
    {
    }

    public CommandExecutionException(string message) : base(message)
    {
    }

    public CommandExecutionException(List<string> errors)
    {
        Errors = errors;
    }

}

