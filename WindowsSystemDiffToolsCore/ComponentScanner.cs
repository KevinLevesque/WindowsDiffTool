using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindoesSystemDiffToolsCore;

namespace WindowsSystemDiffToolsCore
{
    public abstract class ComponentScanner
    {
        public UIListener Listener;
        protected abstract string Name { get; }
        public abstract string ComponentName { get; }
        public abstract string ComponentNamespace { get; }

        public ComponentScanner(){ }

        public void SetUIListener(UIListener listener)
        {
            this.Listener = listener;
        }

        protected void sendMessageToUI(string message)
        {
            Listener.sendStringToUI(message);
        }
        
        public string XmlAttributeComponentName()
        {
            return ComponentName;
        }

        public override string ToString()
        {
            return Name;
        }


        public abstract List<Component> Scan();
        public abstract Type TypeOfComponent();
        public abstract Type TypeOfComponentDiff();
    }
}
