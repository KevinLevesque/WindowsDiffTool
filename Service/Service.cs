using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WindowsSystemDiffToolsCore;
using System.ServiceProcess;

namespace Service
{

    public class Service : Component
    {
        public string DisplayName { get; set; }
        public string ServiceName { get; set; }
        public ServiceControllerStatus Status { get; set; }

        public Service() { }

        public Service(ServiceController service)
        {
            this.DisplayName = service.DisplayName;
            this.ServiceName = service.ServiceName;
            this.Status = service.Status;
        }

 
        public override string ToString()
        {
            return $"{this.DisplayName} [ServiceName '{this.ServiceName}'][Status '{this.getStatusString()}']";
        }

        private string getStatusString()
        {
            switch (this.Status)
            {
                case ServiceControllerStatus.ContinuePending:
                    return "ContinuePending";
                case ServiceControllerStatus.Paused:
                    return "Paused";
                case ServiceControllerStatus.PausePending:
                    return "PausePending";
                case ServiceControllerStatus.Running:
                    return "Running";
                case ServiceControllerStatus.StartPending:
                    return "StartPending";
                case ServiceControllerStatus.Stopped:
                    return "Stopped";
                case ServiceControllerStatus.StopPending:
                    return "StopPending";
                default:
                    return "Unknown??";
            }
        }

    }
}
