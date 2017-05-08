using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindoesSystemDiffToolsCore;

namespace WindowsSystemDiffToolsCore
{
    public interface IComponentScanner
    {
        List<ComponentCore> Scan();
        string XmlAttributeComponentName();
        string ToString();

        void addUIListener(UIListener listener);
        void sendMessageToUI(string message);
        Type typeOfComponent();
    }
}
