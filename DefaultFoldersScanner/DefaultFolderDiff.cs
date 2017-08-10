using System.Collections.Generic;
using System.Linq;
using WindowsSystemDiffToolsCore;

namespace DefaultFolder
{
    public class DefaultFolderDiff : DiffCore
    {
        public DefaultFolderDiff(){}


        List<DefaultFolder> beforeList;
        List<DefaultFolder> afterList;


        public override List<DiffResult> Start()
        {
            List<DiffResult> results = new List<DiffResult>();

            beforeList = GetBeforeData<DefaultFolder>();
            afterList = GetAfterData<DefaultFolder>();


            foreach(DefaultFolder beforeItem in beforeList)
            {
                DefaultFolder afterItem = afterList.FirstOrDefault(x => x.Name == beforeItem.Name);

                if (afterItem == null)
                {
                    //Default folder removed...
                    results.Add(DiffResult.Removed(beforeItem));
                    continue;
                }


                if(beforeItem.Path != afterItem.Path)
                {
                    //Default folder path modified
                    results.Add(DiffResult.Modified(beforeItem, afterItem));
                    continue;
                }   
            }

            foreach(DefaultFolder afterItem in afterList)
            {
                DefaultFolder beforeItem = beforeList.FirstOrDefault(x => x.Name == afterItem.Name);

                if(beforeItem == null)
                {
                    //Default folder didn't exist before, it has been installed
                    results.Add(DiffResult.Added(afterItem));
                }


            }

            return results;
        }


        
    }
}
