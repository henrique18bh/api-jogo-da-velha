﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace JogoDaVelha.CrossCutting.Enum
{
    public enum TypePlayer
    {
        [Description("Player X")]
        X,
        [Description("Player O")]
        O
    }
}
