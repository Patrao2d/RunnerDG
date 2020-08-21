using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{

    public Animator anim;
    private bool _isExpanding;


    private static Shield _instance;

    public static Shield instance
    {
        get { return _instance; }
    }

    private void Start()
    {
        _instance = this;
    }

    void FixedUpdate()
    {
        /*if (Player.instance.isShieldActive)
        {
            transform.Rotate(SpeedValue.instance.speed * 6, 0, 0);
        }*/
    }

    public void ExpandShield()
    {
        if (_isExpanding == true)
        {
            return;
        }
        CameraShake.instance.shakeDuration = 0.5f;
        _isExpanding = true;
        anim.Play("ExpendShieldAnim");
    }

    public void EndOfExpand()
    {
        _isExpanding = false;
    }

    public void DeActiveShield()
    {
        Player.instance.DeActiveShield();
        transform.localScale = new Vector3(1.166667f, 1.166667f, 1.166667f);
    }
}
