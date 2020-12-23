using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
	private Transform RS_bone,LS_bone;
	private Animator anim;
   private Quaternion rciq,lciq,riq,liq;
   const float MOVE_PER_CLOCK = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
       anim = (Animator)FindObjectOfType (typeof(Animator)); 
       RS_bone = anim.GetBoneTransform (HumanBodyBones.RightUpperArm);
       LS_bone = anim.GetBoneTransform (HumanBodyBones.LeftUpperArm);
       riq = RS_bone.rotation;
       liq = LS_bone.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion lb = LS_bone.transform.rotation * Quaternion.Inverse(liq);
        lb.x += 1 * MOVE_PER_CLOCK;
        lb.y += 1* MOVE_PER_CLOCK;
        lb.z += 1 * MOVE_PER_CLOCK;
        LS_bone.rotation = lb * liq;
        Quaternion rb = RS_bone.transform.rotation * Quaternion.Inverse(riq);
        rb.x += 1 * MOVE_PER_CLOCK;
        rb.y += 1 * MOVE_PER_CLOCK;
        rb.z += 1 * MOVE_PER_CLOCK;
        RS_bone.rotation = rb * riq;
    }
}
