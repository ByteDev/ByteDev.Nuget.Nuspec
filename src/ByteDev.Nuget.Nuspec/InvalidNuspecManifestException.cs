using System;
using System.Runtime.Serialization;

namespace ByteDev.Nuget.Nuspec
{
    /// <summary>
    /// Represents an exception when handling an invalid nuspec file.
    /// </summary>
    [Serializable]
    public class InvalidNuspecManifestException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.Nuget.NuspecException" /> class.
        /// </summary>
        public InvalidNuspecManifestException() : base("Nuspec file is invalid.")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.Nuget.NuspecException" /> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public InvalidNuspecManifestException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.Nuget.NuspecException" /> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>       
        public InvalidNuspecManifestException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.Nuget.NuspecException" /> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"></see> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"></see> that contains contextual information about the source or destination.</param>
        protected InvalidNuspecManifestException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}