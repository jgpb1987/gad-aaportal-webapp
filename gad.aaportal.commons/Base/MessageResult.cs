namespace gad.aaportal.commons.Base
{
    public class MessageResult
    {
        public string Code { get; set; } = nameof(CodeMessage.OK);
        public string Description { get; set; } = CodeMessage.OK;
    }
}

