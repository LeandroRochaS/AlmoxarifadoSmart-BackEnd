﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoSmart.Infrastructure.Utils;

public abstract class TransformStringToDecimal
{
    static char[] charsToTrim = { 'R', '$', ' ' };

    public static decimal StringToDecimal(string price)
    {
        return Convert.ToDecimal(price.Trim(charsToTrim));
    }
}
