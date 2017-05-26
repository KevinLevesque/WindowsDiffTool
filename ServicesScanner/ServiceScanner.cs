using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsSystemDiffToolsCore;
using WindoesSystemDiffToolsCore;
using System.ServiceProcess;

namespace ServicesScanner
{
    class ServiceScanner : ComponentScanner
    {
        public ServiceScanner(){ }

        protected override string Name { get { return "Services"; } }

        public override string ComponentName { get { return "Service"; } }
        public override string ComponentNamespace { get { return "ServicesScanner"; } }


        public override List<Component> Scan()
        {
            List<Component> services = new List<Component>();

            ServiceController[] allServices = ServiceController.GetServices();

            foreach (ServiceController service in allServices)
                services.Add(new Service(service));

            Listener.sendStringToUI($"Scanned {services.Count} services");


            return services;
        }
        
        public override Type TypeOfComponent()
        {
            return typeof(Service);
        }

        public override Type TypeOfComponentDiff()
        {
            return typeof(ServiceDiff);
        }

    }
}
