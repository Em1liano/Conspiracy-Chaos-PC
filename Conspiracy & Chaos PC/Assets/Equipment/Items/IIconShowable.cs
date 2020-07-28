using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Equipment.Items
{
    public interface IIconShowable
    {
        /// <summary>
        /// Method for showing icon above item
        /// </summary>
        void ShowIcon(IIconReturnable pickMeUpIcon);
    }
}
