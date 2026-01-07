using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace gad.aaportal.commons.Base
{
    public class MessageResult
    {
        public string Code { get; set; } = nameof(CodeMessage.OK);
        public string Description { get; set; } = CodeMessage.OK;
    }
}

