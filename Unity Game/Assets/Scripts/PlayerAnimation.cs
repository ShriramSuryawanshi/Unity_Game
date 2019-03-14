using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour    
{

    private Animator _anim;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _anim = GetComponentInChildren<Animator>();
    }


    public void Move(float move)
    {
        _anim.SetFloat("Move", Mathf.Abs(move));
    }
}
