using System;

namespace EvalTechnique.Test.Client.Exceptions
{
    internal class VideoTypeNotSupportedException : NotSupportedException
    {
        public VideoTypeNotSupportedException(string message) : base(message) { }
    }
}
