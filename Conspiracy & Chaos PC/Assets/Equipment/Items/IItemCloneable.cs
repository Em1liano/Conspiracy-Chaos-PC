using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Equipment.Items
{
    interface IItemCloneable<T>
    {
        /// <summary>
        /// Clone method for creating raw copy of the object
        /// </summary>
        /// <returns></returns>
        T Clone();
    }
}
