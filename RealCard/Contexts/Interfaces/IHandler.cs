﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealCard.Contexts.Interfaces
{
    public interface IHandler
    {
        object ExecuteSelect(string query, object parameter = null);
        object ExecuteSelect(string query, List<KeyValuePair<string, object>> parameters);
        object ExecuteCommand(string query, List<KeyValuePair<string, object>> parameters);
        object ExecuteCommand(string query, KeyValuePair<string, object> parameters);
    }
}
