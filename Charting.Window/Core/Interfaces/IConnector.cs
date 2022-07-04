using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charting.Window.Core
{
    public interface IConnector
    {
        Task StartCharting();
        void StopCharting();
        bool IsActivated { get; set; }
    }
}
