using gad.aaportal.commons.Base;
namespace gad.aaportal.services.MessageException
{
    public class SystemExceptionCustomized
     : Exception
    {
        public string Code { get; private set; }
        public string Description { get; private set; }

        public SystemExceptionCustomized(string code, string message)
        {
            Code = code;
            Description = message;
        }
        public static SystemExceptionCustomized CreateException(string errorCode, string message)
        {
            return new SystemExceptionCustomized(errorCode, string.Format(message));
        }
        public static SystemExceptionCustomized CreateException(string errorCode, string message, string errorCodeText)
        {
            return new SystemExceptionCustomized(errorCode, string.Format(message, errorCodeText));
        }
        public static SystemExceptionCustomized CreateException(string errorCode, string message, string errorCodeText, string param1)
        {
            return new SystemExceptionCustomized(errorCode, string.Format(message, errorCodeText, param1));
        }
        public static SystemExceptionCustomized CreateException(string errorCode, string message, string errorCodeText, string param1, string param2)
        {
            return new SystemExceptionCustomized(errorCode, string.Format(message, errorCodeText, param1, param2));
        }
        public static SystemExceptionCustomized CreateException(string errorCode, string message, string errorCodeText, string param1, string param2, string param3)
        {
            return new SystemExceptionCustomized(errorCode, string.Format(message, errorCodeText, param1, param2, param3));
        }

        public static MessageResult GetError(Exception ex)
        {
            return ex switch
            {
                SystemExceptionCustomized exc => new MessageResult { Code = exc.Code, Description = exc.Description },
                _ => new MessageResult { Code = nameof(CodeMessage.SERVER_ERROR), Description = CodeMessage.SERVER_ERROR }
            };
        }
    }
}


