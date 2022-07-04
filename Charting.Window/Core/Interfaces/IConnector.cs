using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charting.Window.Core
{
    public interface IConnector
    {
        bool IsActivated { get; set; }
    }
}
