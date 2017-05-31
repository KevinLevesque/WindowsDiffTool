using System.Collections.Generic;
using System.Linq;
using WindowsSystemDiffToolsCore;

namespace InstalledPrograms32bitsScanner
{
    public class InstalledProgram32bitsDiff : DiffCore
    {
        public InstalledProgram32bitsDiff(){}


        List<InstalledProgram32bits> beforeList;
        List<InstalledProgram32bits> afterList;


        public override List<DiffResult> Start()
        {
            List<DiffResult> results = new List<DiffResult>();

            beforeList = GetBeforeData<InstalledProgram32bits>();
            afterList = GetAfterData<InstalledProgram32bits>();


            foreach(InstalledProgram32bits beforeItem in beforeList)
            {
                InstalledProgram32bits afterItem = afterList.FirstOrDefault(x => x.UninstallKey == beforeItem.UninstallKey);

                if (afterItem == null)
                {
                    //Product has been uninstalled, no longer exists in the registry
                    results.Add(DiffResult.Removed(beforeItem));
                    continue;
                }


                if((beforeItem.DisplayName != afterItem.DisplayName) || (beforeItem.DisplayVersion != afterItem.DisplayVersion))
                {
                    //DisplayName or DisplayVersion modified
                    results.Add(DiffResult.Modified(beforeItem, afterItem));
                    continue;
                }   
            }

            foreach(InstalledProgram32bits afterItem in afterList)
            {
                InstalledProgram32bits beforeItem = beforeList.FirstOrDefault(x => x.UninstallKey == afterItem.UninstallKey);

                if(beforeItem == null)
                {
                    //Product didn't exist before, it has been installed
                    results.Add(DiffResult.Added(afterItem));
                }


            }

            return results;
        }


        
    }
}
