using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MJG_34 {
    [CreateAssetMenu(fileName = "TomatoType", menuName = "MJG_34/TomatoType")]
    public class TomatoType : ScriptableObject {
        public Tomato prefab;
        public GameObject spell;
    }
}
