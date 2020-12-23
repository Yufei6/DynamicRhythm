using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
	private Transform RS_bone,LS_bone,LS1_bone;
	public Animator anim;
   private Quaternion rciq,lciq,riq,liq;
   const float MOVE_PER_CLOCK = 0.01f;
   private int i=0;
    // Start is called before the first frame update
    void Start()
    {

       RS_bone = anim.GetBoneTransform (HumanBodyBones.RightUpperArm);
       LS_bone = anim.GetBoneTransform (HumanBodyBones.LeftUpperArm);
       LS1_bone = anim.GetBoneTransform (HumanBodyBones.LeftUpperLeg);

       riq = RS_bone.rotation;
       liq = LS1_bone.rotation;

    }

    // Update is called once per frame
    void Update()
    {
        if(i<6){
          Quaternion lb = LS1_bone.transform.rotation * Quaternion.identity;
          //lb.x += 3 * MOVE_PER_CLOCK;
          //lb.y += 3* MOVE_PER_CLOCK;
          lb.z += 3 * MOVE_PER_CLOCK;
          LS1_bone.rotation = lb * liq;
          i++;
        }
        if(i>=6){
          i++;

        }
        if (i>=50)
        {
          anim.enabled= true;
        }
        if(i>=100){
          anim.enabled= false;
          i=0;
        }

        Quaternion rb = RS_bone.transform.rotation * Quaternion.Inverse(riq);

        //rb.x += 3* MOVE_PER_CLOCK;
        //rb.y += 3 * MOVE_PER_CLOCK;
        rb.z += 10 * MOVE_PER_CLOCK;
        RS_bone.rotation = rb * riq;
    }
}
