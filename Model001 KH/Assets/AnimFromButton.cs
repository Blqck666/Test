using UnityEngine;
using System.Collections;

public class AnimFromButton : MonoBehaviour {

    // Use this for initialization
    public GameObject Main;
    public static Animation a;
    public static GameObject gg;
    public static Animation animation;
    public static bool anim_ka3bourra=false;
    public static bool anim_left = false;
    public static bool anim_right = false;


   public static bool ani = true;
 
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        a = Main.gameObject.GetComponent<Animation>();
        gg = SimpleSelect.SelectedGameObject;
        animation = Main.GetComponent<Animation>();
    }

    public static void animKa3boura() {

        a["Animation_ka3bourra"].speed = 1;
        a.Play("Animation_ka3bourra");
        ani = false;
        anim_ka3bourra = true;


    }



    public static void animObjectLeft() {


        a["ObjectLeft_Animation"].speed = 1;
        a.Play("ObjectLeft_Animation");
        ani = false;

        anim_left = true;

    }




    public static void animObjectRight() {

        a["ObjectRight_Animation"].speed = 1;
        a.Play("ObjectRight_Animation");
        ani = false;
        anim_right = true;


    }
  
    public void anim()
    {
        Global.StopRotateElement();
        if (ani)
        {
           
            if (gg.name == "Ka3boura")
            {

                animKa3boura();

            }
            else if (gg.name == "Object_Left")
            {
                animObjectLeft();
            }
            else if (gg.name == "Object_Right")
            {

                animObjectRight();

            }

        }
        
    }


    public static void animObjectKa3bourraReverse()
    {
      
            animation["Animation_ka3bourra"].speed = -1;
            animation["Animation_ka3bourra"].time = animation["Animation_ka3bourra"].length;
            animation.Play("Animation_ka3bourra");
            ani = true;

        anim_ka3bourra = false;
    }

    public static void animObjectLeftReverse()
    {
        animation["ObjectLeft_Animation"].speed = -1;
        animation["ObjectLeft_Animation"].time = animation["ObjectLeft_Animation"].length;

        animation.Play("ObjectLeft_Animation");
        ani = true;
        anim_left = false;
    }

    
    public static void animObjectRightReverse()
    {

        animation["ObjectRight_Animation"].speed = -1;
        animation["ObjectRight_Animation"].time = animation["ObjectRight_Animation"].length;
        animation.Play("ObjectRight_Animation");
        ani = true;
        anim_right = false;
    }
    public void animRe()
    {
        if (!ani)
        {
            if (gg.name == "Ka3boura")
            {

                animObjectKa3bourraReverse();
            }


            else if (gg.name == "Object_Left")
            {
                animObjectLeftReverse();
            }
            else if (gg.name == "Object_Right")
            {
                animObjectRightReverse();
            }
        }
        
    }



    public void makeTran()
    {

        if (gg.name != "Ka3boura" || gg.name != "Object_Left" || gg.name != "Object_Right")
        {

            

            var renderer = gg.GetComponent<Renderer>();
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
    }














}
