using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsSystemDiffToolsCore;

namespace FreeDiskSpace
{
    public class FreeDiskSpaceDiff : DiffCore
    {
        public FreeDiskSpaceDiff(){}


        List<FreeDiskSpace> beforeList;
        List<FreeDiskSpace> afterList;


        public override List<DiffResult> Start()
        {
            List<DiffResult> results = new List<DiffResult>();

            beforeList = GetBeforeData<FreeDiskSpace>();
            afterList = GetAfterData<FreeDiskSpace>();


            foreach(FreeDiskSpace beforeItem in beforeList)
            {
                FreeDiskSpace afterItem = afterList.FirstOrDefault(x => x.Name == beforeItem.Name);

                if (afterItem == null)
                {
                    //Drive has been deleted
                    results.Add(DiffResult.Removed(beforeItem.ToString()));
                    continue;
                }


                //Drive space modified
                if((beforeItem.AvailaibleSpace != afterItem.AvailaibleSpace))
                {                    
                    results.Add(DiffResult.Modified(beforeItem.ToString(), afterItem.ToString()));
                    continue;
                }   
            }

            foreach(FreeDiskSpace afterItem in afterList)
            {
                FreeDiskSpace beforeItem = beforeList.FirstOrDefault(x => x.Name == afterItem.Name);

                //New Drive
                if(beforeItem == null)
                {                    
                    results.Add(DiffResult.Added(afterItem.ToString()));
                }


            }

            return results;
        }


        
    }
}
