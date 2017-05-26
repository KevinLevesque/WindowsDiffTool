using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsSystemDiffToolsCore;

namespace ScheduledTasksScanner
{
    public class ScheduledTaskDiff : DiffCore
    {

        List<ScheduledTask> beforeList;
        List<ScheduledTask> afterList;

        public override List<DiffResult> Start()
        {
            List<DiffResult> results = new List<DiffResult>();

            beforeList = GetBeforeData<ScheduledTask>();
            afterList = GetAfterData<ScheduledTask>();


            foreach (ScheduledTask beforeItem in beforeList)
            {
                ScheduledTask afterItem = afterList.FirstOrDefault(x => x.Path == beforeItem.Path);

                if (afterItem == null)
                {
                    //Item has been deleted
                    results.Add(DiffResult.Removed(beforeItem));
                    continue;
                }


                //Item modified
                if (beforeItem.LastModifiedDate != afterItem.LastModifiedDate)
                {
                    results.Add(DiffResult.Modified(beforeItem, afterItem));
                    continue;
                }
            }

            foreach (ScheduledTask afterItem in afterList)
            {
                ScheduledTask beforeItem = beforeList.FirstOrDefault(x => x.Path == afterItem.Path);

                //New item
                if (beforeItem == null)
                {
                    results.Add(DiffResult.Added(afterItem));
                }
            }


            return results;
        }
    }
}
