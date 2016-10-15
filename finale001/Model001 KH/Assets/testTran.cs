using UnityEngine;
using System.Collections;

public class testTran : MonoBehaviour {

    Renderer rend;
    // Use this for initialization
	void Start () {
       rend = this.GetComponent<Renderer>();
       
	}
	
	// Update is called once per frame
	void Update () {
        var mat = rend.material;
        var co = mat.color;
        co = new Color(1.0f, 1.0f, 1.0f, 0.2f);
    }
}
