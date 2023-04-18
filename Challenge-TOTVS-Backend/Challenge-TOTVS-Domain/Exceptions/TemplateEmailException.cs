using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.TOTVS.Domain.Exceptions
{
    [Serializable]
    public class TemplateEmailException : Exception
    {
        public TemplateEmailException()
        {
        }

        public TemplateEmailException(string? message) : base(message)
        {
        }

        public TemplateEmailException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected TemplateEmailException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
