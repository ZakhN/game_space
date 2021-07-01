using System.Collections;
using UnityEngine;

namespace Kosmos6
{
    [RequireComponent(typeof(LineRenderer))]
    public class Laser : MonoBehaviour
    {
        public bool CanFire;
        public float MaxDistance = 100f;
        public float Damage = 5f;

        private Coroutine _coroutineFiring;
        private WaitForSeconds _waitForFiring;
        [SerializeField] private float _waitTimeFiring = 0.1f;

        [Header("Links")]
        [SerializeField] private LineRenderer _lineRenderer;
        private ShipWeapons _ShipWeapons;

        private void Awake()
        {
            if (_ShipWeapons == null)
            {
                _ShipWeapons = GetComponentInParent<ShipWeapons>();
            }
            if (_lineRenderer == null)
            {
                _lineRenderer = GetComponent<LineRenderer>();
            }
        }

        void Start()
        {
            if (_lineRenderer == null)
            {
                _lineRenderer = GetComponent<LineRenderer>();
            }
            _waitForFiring = new WaitForSeconds(_waitTimeFiring);
            _lineRenderer.enabled = false;
            CanFire = true;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 targetPosition = FireWeapon(transform.position + transform.forward * MaxDistance);
                VisualizeFiringWeapon(targetPosition);
            }
        }

        public Vector3 FireWeapon(Vector3 targetPosition)
        {
            RaycastHit hitInfo;
            Vector3 direction = targetPosition - transform.position;

            if (Physics.Raycast(transform.position, direction, out hitInfo, MaxDistance))
            {
                var targetHit = hitInfo.transform;
                if (targetHit != null)
                {
                    Debug.Log($"FireWeapon targetHit: {targetHit.name}");
                    targetHit.GetComponent<IDamageable>()?.ReceiveDamage(Damage, targetHit.position, _ShipWeapons._SpaceShip.ShipAgent);
                    //Destroy(targetHit.gameObject);
                    return targetHit.position;
                }
            }

            //if nothing weas hit
            return targetPosition;
        }

        public void VisualizeFiringWeapon(Vector3 targetPosition)
        {
            if (CanFire)
            {
                _lineRenderer.enabled = true;
                _lineRenderer.SetPosition(0, transform.position);
                _lineRenderer.SetPosition(1, targetPosition);
                CanFire = false;

                _coroutineFiring = StartCoroutine(FiringCor());
            }
        }

        private IEnumerator FiringCor()
        {
            yield return _waitForFiring;

            CanFire = true;
            _lineRenderer.enabled = false;
        }
    }
}
