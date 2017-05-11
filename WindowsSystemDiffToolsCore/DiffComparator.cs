using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace WindowsSystemDiffToolsCore
{
    public static class DiffComparator
    {

        public static List<DiffResultsGroup> Compare(List<ComponentGroup> beforeComponentGroup, List<ComponentGroup> afterComponentGroup)
        {
            List<DiffResultsGroup> diffResultGroups = new List<DiffResultsGroup>();

            foreach (ComponentGroup beforeGroup in beforeComponentGroup)
            {
                ComponentGroup afterGroup = afterComponentGroup.FirstOrDefault(x => x.ComponentName == beforeGroup.ComponentName);

                try
                {
                    //Group exists in both lists
                    if (afterGroup != null)
                    {
                        ObjectHandle obj = Activator.CreateInstance(beforeGroup.ComponentNameSpace, beforeGroup.ComponentNameSpace + "." + beforeGroup.ComponentName + "Diff");
                        DiffCore diff = (DiffCore)obj.Unwrap();

                        diff.beforeData = beforeGroup.Components;
                        diff.afterData = afterGroup.Components;

                        List<DiffResult> diffResults = diff.Start();
                        diffResultGroups.Add(new DiffResultsGroup(diffResults, beforeGroup.ComponentName));
                    }
                    else
                    {
                        diffResultGroups.Add(new DiffResultsGroup(null, beforeGroup.ComponentName));
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }                
            }

            foreach (ComponentGroup afterGroup in afterComponentGroup)
            {
                ComponentGroup beforeGroup = beforeComponentGroup.FirstOrDefault(x => x.ComponentName == afterGroup.ComponentName);

                //If beforegroup is null, component was only scanned in the "after" scan. 
                if (beforeGroup == null)
                {
                    diffResultGroups.Add(new DiffResultsGroup(null, beforeGroup.ComponentName));
                }

            }


            return diffResultGroups;
        }


    }
}
