using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour
{
    public bool AllowRotate = true;
   
    public bool AllowScale = true;

    protected virtual void Update()
    {
    
	if (AllowRotate == true)
				{

                    RotateRelative(this.transform, Lean.LeanTouch.TwistDegrees, Lean.LeanTouch.CenterOfFingers);
                }

				if (AllowScale == true)
				{

                    ScaleRelative(this.transform, Lean.LeanTouch.PinchScale, Lean.LeanTouch.CenterOfFingers);
				}
        }



	public void RotateRelative(Transform transform, float angleDelta, Vector2 referencePoint)
        {
    // World position of the reference point
    var worldReferencePoint = Camera.main.ScreenToWorldPoint(referencePoint);

    // Rotate the transform around the world reference point
    transform.RotateAround(worldReferencePoint, Camera.main.transform.forward, angleDelta);
        }


    public void ScaleRelative(Transform transform, float scale, Vector2 referencePoint)
    {
    // Make sure the scale is valid
    if (scale > 0.0f)
        {
        // Screen position of the transform
        var screenPosition = Camera.main.WorldToScreenPoint(transform.position);

        // Push the screen position away from the reference point based on the scale
        screenPosition.x = referencePoint.x + (screenPosition.x - referencePoint.x) * scale;
        screenPosition.y = referencePoint.y + (screenPosition.y - referencePoint.y) * scale;

        // Convert back to world space
        transform.position = Camera.main.ScreenToWorldPoint(screenPosition);

        // Grow the local scale by scale
        transform.localScale *= scale;
        }
    }
}
