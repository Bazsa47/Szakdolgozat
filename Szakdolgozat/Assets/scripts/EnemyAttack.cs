using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float distance;
    public Animation swordSwing;

    public Collider swordCollider;
    void Start()
    {
        target = GetComponent<EnemyClass>().Target; 
    }

    // Update is called once per frame
    void Update()
    {

        //turn to target
        var lookPos = target.position - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 10);

        if (Vector3.Distance(this.transform.position,target.position) <= distance)
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
