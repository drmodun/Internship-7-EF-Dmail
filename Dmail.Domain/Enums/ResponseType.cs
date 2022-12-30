﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dmail.Domain.Enums
{
    public enum ResponseType
    {
        Success,
        NotFound,
        Exists,
        NotChanged,
        ValidationFailed
    }
}
