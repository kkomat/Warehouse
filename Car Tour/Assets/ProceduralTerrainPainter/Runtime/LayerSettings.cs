using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace sc.terrain.proceduralpainter
{
    [System.Serializable]
    public class LayerSettings
    {
        public bool enabled = true;
        public TerrainLayer layer;

        public List<Modifier> modifierStack = new List<Modifier>();
    }

}