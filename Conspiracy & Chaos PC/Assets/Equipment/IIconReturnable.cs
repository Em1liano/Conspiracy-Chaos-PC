using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Equipment
{
    /// <summary>
    /// Interface for icon object to return self.
    /// Only for not doing strange things by my co-workers
    /// </summary>
    public interface IIconReturnable
    {
        GameObject GetIcon();
    }
}
