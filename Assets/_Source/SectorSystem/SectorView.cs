using UnityEngine;

namespace SectorSystem
{
    [RequireComponent(typeof(Collider2D))]
    public sealed class SectorView : MonoBehaviour
    {
        [SerializeField] private string sectorId;

        private Collider2D _collider;

        public string SectorId => sectorId;

        private void Awake()
        {
            _collider = GetComponent<Collider2D>();
        }

        public bool Contains(Vector2 worldPoint)
        {
            return _collider.OverlapPoint(worldPoint);
        }
    }
}