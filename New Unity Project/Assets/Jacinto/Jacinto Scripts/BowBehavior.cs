using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowBehavior : MonoBehaviour {
    bool isRotate = false;
    Animator anim;
    public int currentAnim = 1;
    Vector3 position = Vector3.zero;
	// Use this for initialization
	void Start () {
        this.anim = gameObject.GetComponent<Animator>();
        // this.gameObject.animation
        AnimationClip[] animationClips = anim.runtimeAnimatorController.animationClips;
        foreach(AnimationClip an in animationClips)
        {
            an.wrapMode = WrapMode.Clamp;
        }
        StartCoroutine(RotateBow());
	}
	
	// Update is called once per frame
	void Update () {
		if(isRotate == true)
        {
            if(currentAnim == 1)
            {
                
                this.anim.SetInteger("anim", this.currentAnim);
                this.currentAnim++;
            }
            else
            {
                this.anim.SetInteger("anim", this.currentAnim);
                this.currentAnim--;
            }
            this.isRotate = false;
        }
	}

    IEnumerator RotateBow()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            isRotate = true;
        }
    }
}
