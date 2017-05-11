using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsSystemDiffToolsCore
{
    public interface UIListener
    {
        void sendStringToUI(string message);

        void UpdatePercentComplete(int percentComplete);

        void UpdateCompareFilesList();
    }
}
