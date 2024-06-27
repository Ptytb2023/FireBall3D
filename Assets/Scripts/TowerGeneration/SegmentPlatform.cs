using System;
using UnityEngine;

namespace Generation
{
    [RequireComponent(typeof(MeshRenderer))]
    public class SegmentPlatform : MonoBehaviour
    {
        public void SetMaterial(Material material)
        {
            if (material is null)
                throw new NullReferenceException($"The material should not be null.");


            GetComponent<MeshRenderer>().material = material;
        }
    }
}
