using System.Collections.Generic;
using SectorSystem;
using UnityEngine;

namespace OperativeSystem
{
    public sealed class OperativeMarker : MonoBehaviour
    {
        [SerializeField] private SectorMap sectorMap;
        [SerializeField] private float movementSpeed = 1f;

        private IReadOnlyList<Vector3> _route;
        private int _targetIndex;

        public SectorView CurrentSector { get; private set; }
        public bool IsMoving => _route != null;

        private void Start()
        {
            CurrentSector = sectorMap.FindSector(transform.position);
        }

        private void Update()
        {
            UpdateCurrentSector();

            if (_route == null)
                return;

            MoveAlongRoute();
        }

        public void SetRoute(IReadOnlyList<Vector3> route)
        {
            if (route == null || route.Count < 2)
                return;

            _route = route;
            _targetIndex = 1;
        }

        private void MoveAlongRoute()
        {
            Vector3 target = _route[_targetIndex];

            transform.position = Vector3.MoveTowards(
                transform.position,
                target,
                movementSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, target) > 0.01f)
                return;

            _targetIndex++;

            if (_targetIndex >= _route.Count)
                _route = null;
        }

        private void UpdateCurrentSector()
        {
            SectorView sector = sectorMap.FindSector(transform.position);

            if (sector != null)
                CurrentSector = sector;
        }
    }
}