using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    abstract class SampleBase
    {
        public static string ClassFieldSample = "Miaow!";
        public int InstanceFieldSample;
    }

    class SampleSubclass : SampleBase
    {
        public int SampleProperty { get; set; }
        
        public string SampleMethod()
        {
            List<string> baseList = new List<string>();
            for (int i = 0; i < 255; i++)
            {
                baseList.Add(i.ToString());
            }

            int randomResult = new System.Random().Next()%256;
            foreach (var item in baseList)
            {
                if (randomResult.ToString() == item)
                    return item;
            }

            return "";
        }
    }
}
