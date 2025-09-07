using CatTarot.Core.Input;
using CatTarot.Utils;
using UnityEngine;

namespace CatTarot.Gameplay
{
    public class Card : MonoBehaviour
    {
        [Header("Rotation")]
        [SerializeField, Range(0f, 2f)] private float xAxisSensitivity = 1f;
        [SerializeField, Range(0f, 2f)] private float yAxisSensitivity = 1f;
        [SerializeField, Range(0f, 360f)] private float xAxisMaxRotation = 10f;

        private Vector2 inputDirection;
        private bool allowRotation = false;
        private Quaternion initialRotation;

        private void Awake()
        {
            initialRotation = transform.rotation;
            allowRotation = false;
        }

        private void Update()
        {
            if (allowRotation)
            {
                inputDirection = InputHandler.Instance.MouseDelta;
                inputDirection.y *= xAxisSensitivity;
                inputDirection.x *= yAxisSensitivity;

                // Y-AXIS
                transform.Rotate(Vector3.up, -inputDirection.x, Space.World);

                // X-AXIS
                transform.Rotate(Vector3.right, inputDirection.y, Space.World);

                // CLAMP X + FORCE Z AXIS
                Vector3 rotation = transform.eulerAngles;
                rotation.x = MathUtils.ClampAngle(rotation.x, -xAxisMaxRotation, xAxisMaxRotation);
                rotation.z = 0f;
                transform.eulerAngles = rotation;
            }
        }

        public void ShowFront()
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward, Vector3.up);
        }

        public void ShowBack()
        {
            transform.rotation = Quaternion.LookRotation(Vector3.back, Vector3.up);
        }

        public void OnInteract()
        {
            if (InputHandler.Instance.InteractPressed)
            {
                allowRotation = true;
            }

            if (InputHandler.Instance.InteractReleased)
            {
                allowRotation = false;
            }
        }

#if UNITY_EDITOR
        [Header("Debug")]
        [SerializeField] private Color pivotColor = Color.darkGreen;

        public void OnDrawGizmos()
        {
            Gizmos.color = pivotColor;
            Gizmos.DrawSphere(transform.position, 0.05f);
        }
#endif
    }
}
