using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsSystemDiffToolsCore;

namespace DiskRootScanner
{
    public class DiskRootItemDiff : DiffCore
    {
        List<DiskRootItem> beforeList;
        List<DiskRootItem> afterList;


        public override List<DiffResult> Start()
        {
            List<DiffResult> results = new List<DiffResult>();

            beforeList = GetBeforeData<DiskRootItem>();
            afterList = GetAfterData<DiskRootItem>();


            foreach (DiskRootItem beforeItem in beforeList)
            {
                DiskRootItem afterItem = afterList.FirstOrDefault(x => x.Path == beforeItem.Path);

                if (afterItem == null)
                {
                    //Item has been deleted
                    results.Add(DiffResult.Removed(beforeItem));
                    continue;
                }


                //Item modified
                if (beforeItem.LastWriteDate != afterItem.LastWriteDate)
                {
                    results.Add(DiffResult.Modified(beforeItem, afterItem));
                    continue;
                }
            }

            foreach (DiskRootItem afterItem in afterList)
            {
                DiskRootItem beforeItem = beforeList.FirstOrDefault(x => x.Path == afterItem.Path);

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
