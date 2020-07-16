﻿using System;
using System.Runtime.Serialization;

namespace ByteDev.Nuget
{
    /// <summary>
    /// Represents an exception when handling an invalid nuspec file.
    /// </summary>
    [Serializable]
    public class InvalidNuspecException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.Nuget.NuspecException" /> class.
        /// </summary>
        public InvalidNuspecException() : base("Error while handling a nuspec file.")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.Nuget.NuspecException" /> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public InvalidNuspecException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.Nuget.NuspecException" /> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>       
        public InvalidNuspecException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.Nuget.NuspecException" /> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"></see> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"></see> that contains contextual information about the source or destination.</param>
        protected InvalidNuspecException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}