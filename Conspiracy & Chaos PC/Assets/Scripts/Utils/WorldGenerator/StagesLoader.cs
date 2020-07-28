using Assets.Scripts.Utils.WorldGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Utils.WorldGenerator
{
    public class StagesLoader
    {
        private readonly IEnumerable<Stage> avaiableStages;

        public StagesLoader(IEnumerable<Stage> avaiableStages)
        {
            this.avaiableStages = avaiableStages;
        }

        public Stage GetNext()
        {
            var rnd = new Random();
            var stageIndex = rnd.Next(avaiableStages.Count());

            return avaiableStages.ElementAt(stageIndex) ?? avaiableStages.First();
        }
    }
}
