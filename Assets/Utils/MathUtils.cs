using UnityEngine;

namespace CatTarot.Utils
{
    public class MathUtils : MonoBehaviour
    {

        /// <summary>
        /// Clamps angle in degrees, works with negative numbers. 
        /// </summary>
        /// <returns>Angle ranged from 0 to 360</returns>
        public static float ClampAngle(float angle, float from, float to)
        {
            if (angle < 0f)
                angle = 360 + angle;

            if (angle > 180f)
                return Mathf.Max(angle, 360 + from);

            return Mathf.Min(angle, to);
        }
    }
}