﻿using System.Runtime.Serialization;

namespace Phonebook
{
  [Serializable]
  internal class NoSuchElementException : Exception
  {
    public NoSuchElementException()
    {
    }

    public NoSuchElementException(string? message) : base(message)
    {
    }

    public NoSuchElementException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected NoSuchElementException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
  }
}