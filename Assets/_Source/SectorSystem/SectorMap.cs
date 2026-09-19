using System.Collections.Generic;
using UnityEngine;

namespace SectorSystem
{
    public sealed class SectorMap : MonoBehaviour
    {
        [SerializeField] private List<SectorView> sectors = new();

        public SectorView FindSector(Vector2 worldPoint)
        {
            foreach (SectorView sector in sectors)
            {
                if (sector.Contains(worldPoint))
                    return sector;
            }

            return null;
        }
    }
}