using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

    // Use this for initialization
    public Material a;

    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            var selectedobject_color = SimpleSelect.SelectedGameObject;
            string g = this.transform.name;
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                //if (selectedobject_color.name != "Ka3boura" || selectedobject_color.name != "Object_Left" || selectedobject_color.name != "Object_Right")
                //{
                    
                //        Debug.Log("aze");
                //    GameObject gg = hit.collider.gameObject;

                //    var renderer = gg.GetComponent<Renderer>();
                //    Material[] material = renderer.materials;
                //    for (int i = 0; i < material.Length; i++)
                //    {
                //        material[i].SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                //        material[i].SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                //        material[i].SetInt("_ZWrite", 0);
                //        material[i].DisableKeyword("_ALPHATEST_ON");
                //        material[i].EnableKeyword("_ALPHABLEND_ON");
                //        material[i].DisableKeyword("_ALPHAPREMULTIPLY_ON");
                //        material[i].renderQueue = 3000;
                //        material[i].color = new Color(1.0f, 1.0f, 1.0f, 0.1f);
                //    }
                //}
                
                
                
            }
        }
    }
}
