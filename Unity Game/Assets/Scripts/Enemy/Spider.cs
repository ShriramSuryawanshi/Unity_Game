using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageable
{

    public int Health { get; set; }
    public GameObject acidEffectPrefab;

    public override void Init()
    {
        base.Init();
        Health = base.health;
    }


    public override void Update()
    {
        //base.Update();
    }


    public void Damage()
    {
        Health--;

        if (Health < 1)
        {
            isDead = true;
            anim.SetTrigger("Death");
        } 
    }


    public override void Movement()
    {
        //base.Movement();
    }


    public void Attack()
    {
        Instantiate(acidEffectPrefab, transform.position, Quaternion.identity);
    }
}
