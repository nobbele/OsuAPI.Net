using System;
using System.Collections.Generic;
using System.Text;

namespace OsuAPI.Net.Models.V1
{
    public enum Status
    {
        Graveyard = -2,
        WIP = -1,
        Pending = 0,
        Ranked = 1,
        Approved = 2,
        Qualified = 3,
        Loved = 4
    }
}
