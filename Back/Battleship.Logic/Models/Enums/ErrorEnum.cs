using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Battleship.Logic.Models.Enums
{
    public enum ErrorEnum
    {
        #region SHIP EXCEPTIONS
        [Description("The ship cannot exceed grid limits")]
        SHIP_EXCEED_LIMITS,
        [Description("A ship cannot be placed on another ship")]
        SHIP_PLACED_ON_OTHER,
        #endregion
    }
}
