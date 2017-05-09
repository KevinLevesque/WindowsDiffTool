using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsSystemDiffToolsCore
{
    public abstract class DiffCore
    {
        public List<Component> beforeData;
        public List<Component> afterData;

        protected List<T> GetBeforeData<T>()
        {
            List<T> list = new List<T>();
            foreach(Component component in beforeData)
            {
                list.Add((dynamic)component);
            }

            return list;
        }

        protected List<T> GetAfterData<T>()
        {
            List<T> list = new List<T>();
            foreach (Component component in afterData)
            {
                list.Add((dynamic)component);
            }

            return list;
        }

        public abstract List<DiffResult> Start();

    }
}
