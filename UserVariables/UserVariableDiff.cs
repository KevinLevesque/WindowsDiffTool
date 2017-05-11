using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsSystemDiffToolsCore;

namespace UserVariables
{
    public class UserVariableDiff : DiffCore
    {
        public UserVariableDiff(){}


        List<UserVariable> beforeList;
        List<UserVariable> afterList;


        public override List<DiffResult> Start()
        {
            List<DiffResult> results = new List<DiffResult>();

            beforeList = GetBeforeData<UserVariable>();
            afterList = GetAfterData<UserVariable>();


            foreach(UserVariable beforeItem in beforeList)
            {
                UserVariable afterItem = afterList.FirstOrDefault(x => x.Name == beforeItem.Name);

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

            foreach(UserVariable afterItem in afterList)
            {
                UserVariable beforeItem = beforeList.FirstOrDefault(x => x.Name == afterItem.Name);

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
