using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsSystemDiffToolsCore;

namespace MyDocuments
{
    public class MyDocumentsItemDiff : DiffCore
    {
        List<MyDocumentsItem> beforeList;
        List<MyDocumentsItem> afterList;


        public override List<DiffResult> Start()
        {
            List<DiffResult> results = new List<DiffResult>();

            beforeList = GetBeforeData<MyDocumentsItem>();
            afterList = GetAfterData<MyDocumentsItem>();


            foreach (MyDocumentsItem beforeItem in beforeList)
            {
                MyDocumentsItem afterItem = afterList.FirstOrDefault(x => x.Path == beforeItem.Path);

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

            foreach (MyDocumentsItem afterItem in afterList)
            {
                MyDocumentsItem beforeItem = beforeList.FirstOrDefault(x => x.Path == afterItem.Path);

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
