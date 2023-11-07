using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
public class MonsterRealController : MonoBehaviour
{
    Animator anim;
    Rigidbody rig;
    public NavMeshAgent agent;

    //public Transform leftHandTarget;
    //public Transform rightHandTarget;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        rig = this.GetComponent<Rigidbody>();
        anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
        anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
        anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
        anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnAnimatorIK(int layerIndex)
    //{
    //    anim.SetIKPosition(AvatarIKGoal.LeftHand, leftHandTarget.position);
    //    anim.SetIKPosition(AvatarIKGoal.RightHand, rightHandTarget.position);
    //    anim.SetIKRotation(AvatarIKGoal.LeftHand, leftHandTarget.rotation);
    //    anim.SetIKRotation(AvatarIKGoal.RightHand, rightHandTarget.rotation);
    //}

    private void FixedUpdate()
    {
        Vector3 offset = agent.transform.position - this.transform.position;
        rig.velocity = offset.normalized * offset.magnitude;
        anim.SetFloat("speed", rig.velocity.magnitude);
        offset.y = 0;
        if(offset.magnitude > .2f)
        {
            anim.SetBool("IsWalking", true);
            Quaternion lookRotation = Quaternion.LookRotation(agent.velocity.normalized);
            this.transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * agent.angularSpeed);
        }
        else
        {
            anim.SetBool("IsWalking", false);
        }

    }
}
