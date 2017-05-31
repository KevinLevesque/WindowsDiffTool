using System.Collections.Generic;
using System.Linq;
using WindowsSystemDiffToolsCore;

namespace SystemEnvironmentVariablesScanner
{
    public class SystemEnvironmentVariableDiff : DiffCore
    {
        public SystemEnvironmentVariableDiff(){}


        List<SystemEnvironmentVariable> beforeList;
        List<SystemEnvironmentVariable> afterList;


        public override List<DiffResult> Start()
        {
            List<DiffResult> results = new List<DiffResult>();

            beforeList = GetBeforeData<SystemEnvironmentVariable>();
            afterList = GetAfterData<SystemEnvironmentVariable>();


            foreach(SystemEnvironmentVariable beforeItem in beforeList)
            {
                SystemEnvironmentVariable afterItem = afterList.FirstOrDefault(x => x.Name == beforeItem.Name);

                if (afterItem == null)
                {
                    //Variable has been deleted
                    results.Add(DiffResult.Removed(beforeItem));
                    continue;
                }


                //Value of variable modified
                if((beforeItem.Value != afterItem.Value))
                {                    
                    results.Add(DiffResult.Modified(beforeItem, afterItem));
                    continue;
                }   
            }

            foreach(SystemEnvironmentVariable afterItem in afterList)
            {
                SystemEnvironmentVariable beforeItem = beforeList.FirstOrDefault(x => x.Name == afterItem.Name);

                //New Variable
                if(beforeItem == null)
                {                    
                    results.Add(DiffResult.Added(afterItem));
                }


            }

            return results;
        }


        
    }
}
