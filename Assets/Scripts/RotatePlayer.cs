using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayer : MonoBehaviour
{
    private Animator _anim;

    private static RotatePlayer _instance;

    public static RotatePlayer instance
    {
        get { return _instance; }
    }

    private void Start()
    {
        _instance = this;
        _anim = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        transform.Rotate(SpeedValue.instance.speed * 11, 0, 0);
    }

    public void WinAnim()
    {
        _anim.applyRootMotion = false;
        _anim.SetTrigger("Win");
    }

    public void LoseAnim()
    {
        _anim.applyRootMotion = false;
        _anim.SetTrigger("Lose");
    }

    public void JumpAnim()
    {
        if (!_anim.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
        {
            _anim.SetTrigger("Jump");
        }
        
    }

    public void SplashAnim()
    {

    }
}
