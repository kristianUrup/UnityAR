using System;
using Unity.Entities;

namespace Assets.My_Assets
{
    public class CardComponent : IComponentData
    {
        public String name;
        public float healthPoints;
        public String healthType;
        public String weaknessType;
        public String resistanceType;
        public float resistanceNumber;


    }
}
