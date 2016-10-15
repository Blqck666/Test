using UnityEngine;
using System.Collections;

public class Global : MonoBehaviour {


    public GameObject e1, e2;
    public GameObject water;
    public GameObject water1;
    public static GameObject[] ElementsToRotate;
    public GameObject[] ElementsChange;
    public static bool  waters =false;
    public GameObject ObjectToTransparence;
    public Material MaterielToSave;
    private static int speed = 5;
    public static bool OnRotate = false;
    public static bool transparenc = false;
    public Material[] elementchangecolor;
    // Use this for initialization
    void Start() {
       
        ElementsToRotate = new GameObject[2];

        ElementsToRotate[0] = e1;
        ElementsToRotate[1] = e2;
    
   
        var renderer1 = ObjectToTransparence.GetComponent<Renderer>();
        ElementsChange = GameObject.FindGameObjectsWithTag("Player");
       
     

        MaterielToSave = renderer1.material;


    }
	
	// Update is called once per frame
	void Update () {

        Material[] elementchangecolor; 
        if (OnRotate)
        {
       
            foreach (GameObject respawn in ElementsChange)
            {
                respawn.transform.Rotate(new Vector3(30, 0, 0) * Time.deltaTime * speed);

                elementchangecolor = respawn.GetComponent<Renderer>().materials;

                foreach (Material m in elementchangecolor)
                {

                    m.color = Color.yellow;
                }

            }

            foreach (GameObject respawn in ElementsToRotate)
            {
                respawn.transform.Rotate(new Vector3(30, 0, 0) * Time.deltaTime * speed);

                elementchangecolor = respawn.GetComponent<Renderer>().materials;

                foreach (Material m in elementchangecolor)
                {

                    m.color = Color.yellow;
                }

            }
            


        }

        if (waters) {
            water.SetActive(true);
            water1.SetActive(true);
        }

        else
        {

            water.SetActive(false);
            water1.SetActive(false);
        }


        if (transparenc)
        {
            var renderer = ObjectToTransparence.GetComponent<Renderer>();
            Material[] material = renderer.materials;
            for (int i = 0; i < material.Length; i++)
            {
                material[i].SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                material[i].SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                material[i].SetInt("_ZWrite", 0);
                material[i].DisableKeyword("_ALPHATEST_ON");
                material[i].EnableKeyword("_ALPHABLEND_ON");
                material[i].DisableKeyword("_ALPHAPREMULTIPLY_ON");
                material[i].renderQueue = 3000;
                material[i].color = new Color(1.0f, 1.0f, 1.0f, 0.1f);
            }


        }

         if (transparenc==false)
        {
            Debug.Log("wsel");


        }


        //if (SimpleSelect.SelectObjectRight)
        //{
        //    var renderer = ObjectToTransparence.GetComponent<Renderer>();
        //    renderer.material.color = Color.red;
        //}
        //else
        //{

        //    var renderer = ObjectToTransparence.GetComponent<Renderer>();
        //    renderer.material.color = Color.white;
        //}

    }

    public void RotateElement() {
        waters = true;

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
        OnRotate = true;
        Debug.Log("salut");


       


    }

    public void testc()
    {
        OnRotate = false;
        waters = false;
        transparenc = false;
        Debug.Log("Stop");



        Material[] elementchangecolor;
        foreach (GameObject respawn in ElementsToRotate)
        {
            respawn.transform.Rotate(new Vector3(30, 0, 0) * Time.deltaTime * speed);

            elementchangecolor = respawn.GetComponent<Renderer>().materials;

            foreach (Material m in elementchangecolor)
            {

                m.color = Color.white;
            }

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
        
        } }

    public static void StopRotateElement()
    {
        OnRotate = false;
        waters = false;
        transparenc = false;
        Debug.Log("Stop");

       
        Material[] elementchangecolor;
        foreach (GameObject respawn in ElementsToRotate)
        {
            respawn.transform.Rotate(new Vector3(30, 0, 0) * Time.deltaTime * speed);

            elementchangecolor = respawn.GetComponent<Renderer>().materials;

            foreach (Material m in elementchangecolor)
            {

                m.color = Color.white;
            }

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

        
        
    }

    public void transparence()
    {
        transparenc = true;

       

        
    }

    public void transparenceReverse()
    {

       
        transparenc = false;


    }




}
