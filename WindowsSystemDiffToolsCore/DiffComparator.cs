using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace WindowsSystemDiffToolsCore
{
    public class DiffComparator
    {
        UIListener Listener;

        public DiffComparator(UIListener listener) {
            Listener = listener;
        }

        public List<DiffResultsGroup> Compare(List<ComponentGroup> beforeComponentGroup, List<ComponentGroup> afterComponentGroup)
        {
            List<DiffResultsGroup> diffResultGroups = new List<DiffResultsGroup>();

            int count = 0;
            foreach (ComponentGroup beforeGroup in beforeComponentGroup)
            {
                Listener.UpdateCompareMessage($"Currently comparing {beforeGroup.ComponentName}");

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


                    count++;
                    Listener.UpdateCompareMessage($"Comparing {beforeGroup.ComponentName} completed." + Environment.NewLine);
                    Listener.UpdateComparePercentComplete((int)Math.Ceiling(((float)count / (float)beforeComponentGroup.Count) * (float)100));
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
                    diffResultGroups.Add(new DiffResultsGroup(null, afterGroup.ComponentName));
                }

            }


            return diffResultGroups;
        }


    }
}
