using Example01.Core;
using UnityEngine;

namespace Example01.Arsenal
{
    public class BulletsPool : MonobehaviourPoolTemplate<Bullet>
    {
        public BulletsPool(Bullet prefab, Transform createPoint) : base(prefab, createPoint) { }
    }
}
