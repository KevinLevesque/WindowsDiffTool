using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsSystemDiffToolsCore;

namespace OutlookAddinsScanner
{
    public class OutlookAddinDiff : DiffCore
    {
        public OutlookAddinDiff(){}


        List<OutlookAddin> beforeList;
        List<OutlookAddin> afterList;


        public override List<DiffResult> Start()
        {
            List<DiffResult> results = new List<DiffResult>();

            beforeList = GetBeforeData<OutlookAddin>();
            afterList = GetAfterData<OutlookAddin>();


            foreach(OutlookAddin beforeItem in beforeList)
            {
                OutlookAddin afterItem = afterList.FirstOrDefault(x => x.Id == beforeItem.Id);

                if (afterItem == null)
                {
                    //Addin has been uninstalled, no longer exists in the registry
                    results.Add(DiffResult.Removed(beforeItem));
                    continue;
                }


                if((beforeItem.Name != afterItem.Name))
                {
                    //Addin modified
                    results.Add(DiffResult.Modified(beforeItem, afterItem));
                    continue;
                }   
            }

            foreach(OutlookAddin afterItem in afterList)
            {
                OutlookAddin beforeItem = beforeList.FirstOrDefault(x => x.Id == afterItem.Id);

                if(beforeItem == null)
                {
                    //Addin didn't exist before, it has been installed
                    results.Add(DiffResult.Added(afterItem));
                }


            }

            return results;
        }


        
    }
}
