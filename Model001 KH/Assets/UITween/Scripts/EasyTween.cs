using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.UI;
using UITween;

/**** * 
 * Animation Initialized Object
 * 
 * new AnimationParts(AnimationParts.State.CLOSE, 
	                  false, 
	                  AnimationParts.EndTweenClose.DEACTIVATE, 
	                  AnimationParts.CallbackCall.END_OF_INTRO_ANIM, 
					  new UnityEvent(),
	                  new UnityEvent());
 * 
 * 
 ****/
[System.Serializable]
public class EasyTween : MonoBehaviour
{

    public RectTransform rectTransform;
    public AnimationParts animationParts = new AnimationParts(AnimationParts.State.CLOSE,
                                               false,
                                               false,
                                               false,
                                               AnimationParts.EndTweenClose.DEACTIVATE,
                                               AnimationParts.CallbackCall.NOTHING,
                                               new UnityEvent(),
                                               new UnityEvent());

    private CurrentAnimation currentAnimationGoing;

    public GameObject Main;

    #region Public_Methods

    public EasyTween()
    {
        CheckIfCurrenAnimationGoingExits();
    }

    public void OpenCloseObjectAnimation()
    {
        rectTransform.gameObject.SetActive(true);

        TriggerOpenClose();
       
    }

    public bool IsObjectOpened()
    {
        return currentAnimationGoing.IsObjectOpened();
    }

    public void SetUnscaledTimeAnimation(bool UnscaledTimeAnimation)
    {
        animationParts.UnscaledTimeAnimation = UnscaledTimeAnimation;
    }

    public void SetAnimatioDuration(float duration)
    {
        if (duration > 0f)
            currentAnimationGoing.SetAniamtioDuration(duration);
        else
            currentAnimationGoing.SetAniamtioDuration(.01f);
    }

    public float GetAnimationDuration()
    {
        return currentAnimationGoing.GetAnimationDuration();
    }

    public void SetAnimationPosition(Vector2 StartAnchoredPos, Vector2 EndAnchoredPos, AnimationCurve EntryTween, AnimationCurve ExitTween)
    {
        currentAnimationGoing.SetAnimationPos(StartAnchoredPos, EndAnchoredPos, EntryTween, ExitTween, rectTransform);
    }

    public void SetAnimationScale(Vector3 StartAnchoredScale, Vector3 EndAnchoredScale, AnimationCurve EntryTween, AnimationCurve ExitTween)
    {
        currentAnimationGoing.SetAnimationScale(StartAnchoredScale, EndAnchoredScale, EntryTween, ExitTween);
    }

    public void SetAnimationRotation(Vector3 StartAnchoredEulerAng, Vector3 EndAnchoredEulerAng, AnimationCurve EntryTween, AnimationCurve ExitTween)
    {
        currentAnimationGoing.SetAnimationRotation(StartAnchoredEulerAng, EndAnchoredEulerAng, EntryTween, ExitTween);
    }

    public void SetFade(bool OverrideFade)
    {
        currentAnimationGoing.SetFade(OverrideFade);
    }

    public void SetFade()
    {
        currentAnimationGoing.SetFade(false);
    }

    public void SetFadeStartEndValues(float startValua, float endValue)
    {
        currentAnimationGoing.SetFadeValuesStartEnd(startValua, endValue);
    }

    public void SetAnimationProperties(AnimationParts animationParts)
    {
        this.animationParts = animationParts;
        currentAnimationGoing = new CurrentAnimation(animationParts);
    }

    public void ChangeSetState(bool opened)
    {
        currentAnimationGoing.SetStatus(opened);
    }

    #endregion

    #region Private_Methods

    private void Start()
    {
        AnimationParts.OnDisableOrDestroy += CheckTriggerEndState;
    }

    private void OnDestroy()
    {
        AnimationParts.OnDisableOrDestroy -= CheckTriggerEndState;
    }

    private void Update()
    {
        currentAnimationGoing.AnimationFrame(rectTransform);
    }

    private void LateUpdate()
    {
        currentAnimationGoing.LateAnimationFrame(rectTransform);
    }

    private void TriggerOpenClose()
    {
        if (!currentAnimationGoing.IsObjectOpened())
        {
            currentAnimationGoing.PlayOpenAnimations();

            Debug.Log("eclaté");
            Animation animation = Main.GetComponent<Animation>();
            //Debug.Log("qsd");
            //var gg = SimpleSelect.SelectedGameObject;
            //if (gg.name == "Ka3boura")
            //{
            //    animation["Animation_ka3bourra"].speed = -1;
            //    animation["Animation_ka3bourra"].time = animation["Animation_ka3bourra"].length;
            //    animation.Play("Animation_ka3bourra");
            //}
            //else if (gg.name == "Object_Left")
            //{
            //    animation["ObjectLeft_Animation"].speed = -1;
            //    animation["ObjectLeft_Animation"].time = animation["ObjectLeft_Animation"].length;

            //    animation.Play("ObjectLeft_Animation");
            //}
            //else if (gg.name == "Object_Right")
            //{

            //    animation.Play("ObjectRight_Animation");
            //}
        }
        else
        {
            
            currentAnimationGoing.PlayCloseAnimations();
            Debug.Log("j,lk");
            //var a = Main.gameObject.GetComponent<Animation>();
            //Debug.Log("raja3");
            //var gg = SimpleSelect.SelectedGameObject;
            //if (gg.name == "Ka3boura")
            //{
            //    a.Play("Animation_ka3bourra");
            //}
            //else if (gg.name == "Object_Left")
            //{
            //    a.Play("ObjectLeft_Animation");
            //}
            //else if (gg.name == "Object_Right")
            //{
                
            //    a.Play("ObjectRight_Animation");
            //}
        }
    }

    private void CheckTriggerEndState(bool disable, AnimationParts part)
    {
        if (part != animationParts)
            return;

        if (disable)
        {
            rectTransform.gameObject.SetActive(false);
        }
        else
        {
            if (gameObject && !rectTransform.gameObject == gameObject)
            {
                Destroy(gameObject);
            }
			
            DestroyImmediate(rectTransform.gameObject);
        }
    }

    private void CheckIfCurrenAnimationGoingExits()
    {
        if (currentAnimationGoing == null)
        {
            SetAnimationProperties(this.animationParts);
        }
    }

    #endregion
}