using UnityEngine;

// This script allows you to select a GameObject using any finger, as long it has a collider
public class SimpleSelect : MonoBehaviour
{
	[Tooltip("This stores the layers we want the raycast to hit (make sure this GameObject's layer is included!)")]
	public LayerMask LayerMask = UnityEngine.Physics.DefaultRaycastLayers;
	
	[Tooltip("The previously selected GameObject")]
	public static GameObject SelectedGameObject;
    public GameObject ka3boura;
    public GameObject Left;
    public GameObject Right;
    public GameObject[] ElementsChange;
    public Canvas canv;
    public static bool SelectObjectRight = false ;

    public Canvas canvTransparence;
    public Animation aani;

   


    protected virtual void OnEnable()
	{
		// Hook into the OnFingerTap event
		Lean.LeanTouch.OnFingerTap += OnFingerTap;
	}
	
	protected virtual void OnDisable()
	{
		// Unhook from the OnFingerTap event
		Lean.LeanTouch.OnFingerTap -= OnFingerTap;
	}


    public void update() {
        if (Global.OnRotate)
        {
            if (canv.enabled == true)
            {
                canv.enabled = false;

            }

        }


    }
	public void OnFingerTap(Lean.LeanFinger finger)
	{
		// Raycast information
		var ray = finger.GetRay();
		var hit = default(RaycastHit);
        canv = GameObject.Find("Canvas").GetComponent<Canvas>();
        aani = GetComponent<Animation>();
        canvTransparence= GameObject.Find("Canvast").GetComponent<Canvas>();

        // Was this finger pressed down on a collider?
        if (Physics.Raycast(ray, out hit, float.PositiveInfinity, LayerMask) == true)
		{
			// Remove the color from the currently selected one?
			if (SelectedGameObject != null)
			{
				ColorGameObject(ElementsChange, Color.white);
			}

			SelectedGameObject = hit.collider.gameObject;

            if (SelectedGameObject == ka3boura)
            {
                ElementsChange = GameObject.FindGameObjectsWithTag("Player");
                ColorGameObject(ElementsChange, Color.green);
                canv.enabled = true;
                canvTransparence.enabled = false;

                if (AnimFromButton.anim_left) {
                    AnimFromButton.animObjectLeftReverse();

                }

                if (AnimFromButton.anim_right)
                {
                    AnimFromButton.animObjectRightReverse();

                }
               // aani.Play("Animation_ka3bourra");

            }
            else if (SelectedGameObject == Left)
            {
                ElementsChange = GameObject.FindGameObjectsWithTag("left");

                ColorGameObject(ElementsChange, Color.red);
                canv.enabled = true;
                canvTransparence.enabled = true;
                //aani.Play("ObjectLeft_Animation");

                if (AnimFromButton.anim_ka3bourra)
                {
                    AnimFromButton.animObjectKa3bourraReverse();

                }

                if (AnimFromButton.anim_right)
                {
                    AnimFromButton.animObjectRightReverse();

                }
            }

            else if (SelectedGameObject == Right)
            {

                SelectObjectRight = true;
                ElementsChange = GameObject.FindGameObjectsWithTag("right");

                ColorGameObject(ElementsChange, Color.blue);
                canv.enabled = true;
                canvTransparence.enabled = false;

                // aani.Play("ObjectRight_Animation");


                if (AnimFromButton.anim_ka3bourra)
                {
                    AnimFromButton.animObjectKa3bourraReverse();

                }

                if (AnimFromButton.anim_left)
                {
                    AnimFromButton.animObjectLeftReverse();

                }


            }
            else {
                SelectObjectRight = false;
                canv.enabled = false;
                canvTransparence.enabled = false;
              ColorGameObject(ElementsChange, Color.white);
                if (AnimFromButton.anim_ka3bourra)
                {
                    AnimFromButton.animObjectKa3bourraReverse();

                }

                if (AnimFromButton.anim_right)
                {
                    AnimFromButton.animObjectRightReverse();

                }

                if (AnimFromButton.anim_left)
                {
                    AnimFromButton.animObjectLeftReverse();

                }
            }



            //canv.enabled = false;



            Debug.Log(SelectedGameObject);
		}
	}

	private static void ColorGameObject(GameObject[] gameObject, Color color)
	{
		// Make sure the GameObject exists
		if (gameObject != null)
		{

            for (int i=0;i< gameObject.Length; i++)
            {
                
                // Get renderer from this GameObject
                var renderer = gameObject[i].GetComponent<Renderer>();

                // Make sure the Renderer exists
                if (renderer != null)
                {
                    // Get material copy from this renderer
                    var material = renderer.material;

                    // Make sure the material exists
                    if (material != null)
                    {
                        // Set new color
                        material.color = color;
                    }
                }
            }
			
			

	
		}
	}
}