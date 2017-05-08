using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsSystemDiffToolsCore
{
    public class ScannerCore
    {

        public UIListener Listener;

        public ScannerCore(UIListener listener)
        {
            this.Listener = listener;
        }

        public ScannerCore() { }

    }
}
