using System.Collections.Generic;
using System.Linq;
using WindowsSystemDiffToolsCore;

namespace StartMenuScanner
{
    public class StartMenuItemDiff : DiffCore
    {

        List<StartMenuItem> beforeList;
        List<StartMenuItem> afterList;

        public override List<DiffResult> Start()
        {
            List<DiffResult> results = new List<DiffResult>();

            beforeList = GetBeforeData<StartMenuItem>();
            afterList = GetAfterData<StartMenuItem>();


            foreach (StartMenuItem beforeItem in beforeList)
            {
                StartMenuItem afterItem = afterList.FirstOrDefault(x => x.Path == beforeItem.Path);

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

            foreach (StartMenuItem afterItem in afterList)
            {
                StartMenuItem beforeItem = beforeList.FirstOrDefault(x => x.Path == afterItem.Path);

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
