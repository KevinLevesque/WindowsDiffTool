using System.Collections.Generic;
using System.Linq;
using WindowsSystemDiffToolsCore;

namespace ServicesScanner
{
    public class ServiceDiff : DiffCore
    {
        public ServiceDiff(){}


        List<Service> beforeList;
        List<Service> afterList;


        public override List<DiffResult> Start()
        {
            List<DiffResult> results = new List<DiffResult>();

            beforeList = GetBeforeData<Service>();
            afterList = GetAfterData<Service>();


            foreach(Service beforeItem in beforeList)
            {
                Service afterItem = afterList.FirstOrDefault(x => x.ServiceName == beforeItem.ServiceName);

                if (afterItem == null)
                {
                    //Service has been deleted
                    results.Add(DiffResult.Removed(beforeItem));
                    continue;
                }


                //Name or status modified
                if((beforeItem.DisplayName != afterItem.DisplayName) || (beforeItem.Status != afterItem.Status))
                {                    
                    results.Add(DiffResult.Modified(beforeItem, afterItem));
                    continue;
                }   
            }

            foreach(Service afterItem in afterList)
            {
                Service beforeItem = beforeList.FirstOrDefault(x => x.ServiceName == afterItem.ServiceName);

                //New service
                if(beforeItem == null)
                {                    
                    results.Add(DiffResult.Added(afterItem));
                }


            }

            return results;
        }


        
    }
}
