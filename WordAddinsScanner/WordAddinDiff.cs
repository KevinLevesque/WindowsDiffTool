using System.Collections.Generic;
using System.Linq;
using WindowsSystemDiffToolsCore;

namespace WordAddinsScanner
{
    public class WordAddinDiff : DiffCore
    {
        public WordAddinDiff(){}


        List<WordAddin> beforeList;
        List<WordAddin> afterList;


        public override List<DiffResult> Start()
        {
            List<DiffResult> results = new List<DiffResult>();

            beforeList = GetBeforeData<WordAddin>();
            afterList = GetAfterData<WordAddin>();


            foreach(WordAddin beforeItem in beforeList)
            {
                WordAddin afterItem = afterList.FirstOrDefault(x => x.Id == beforeItem.Id);

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

            foreach(WordAddin afterItem in afterList)
            {
                WordAddin beforeItem = beforeList.FirstOrDefault(x => x.Id == afterItem.Id);

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
