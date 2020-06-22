using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaidHex
{
    class GameDataSource
    {
        public static List<ComboItem> GetDenDataSource()
        {

            var locationStrings = RaidHex.Properties.Resources.locations_zh.Split('\n');
            
            var list = new List<ComboItem>(DenInfo.maxDenSize);
            for (int i = 0; i < DenInfo.maxDenSize; i++)
                list.Add(new ComboItem($"{i+1}:{locationStrings[DenInfo.getLocation(i)]}", i));
            return list;
        }

        public static List<ComboItem> GetDenTypeSource()
        {
            var locationStrings = RaidHex.Properties.Resources.denType_zh.Split('\n');

            var list = new List<ComboItem>(7);
            for (int i = 0; i < 7;i++)
                list.Add(new ComboItem(locationStrings[i], 0));
            return list;
        }
    }
}
