using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    public EnemyClass ec;
    [SerializeField]
    private float distance;
    public Animation swordSwing;

    public Collider swordCollider;


    // Update is called once per frame
    void Update()
    {

        //turn to target
        var lookPos = ec.Target.position - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 10);

        if (Vector3.Distance(this.transform.position, ec.Target.position) <= distance)
        {           
            //attack
            if (!swordSwing.isPlaying)
            {
                swordCollider.enabled = false;
                swordSwing.Play();
            }
        }

        if (swordSwing.isPlaying)
        {
            swordCollider.enabled = true;
        }
    }
}
