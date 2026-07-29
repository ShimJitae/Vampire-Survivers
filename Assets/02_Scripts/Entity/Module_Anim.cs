using UnityEngine;

public class Module_Anim : MonoBehaviour
{
    Animator animator;
    SpriteRenderer sr;

    void Awake()
    {
        animator = GetComponent<Animator>();

        sr = GetComponent<SpriteRenderer>();
    }

    public void SetMoveAnimation(string paraName, Vector2 currDirection)
    {
        float animV = currDirection.x != 0 ? 1 : currDirection.y != 0 ? 1 : 0;
        animator.SetFloat(paraName, animV);

        SetFlipX(currDirection.x);
    }

    void SetFlipX(float currX)
    {
        if (currX < 0)
        {
            sr.flipX = true;
        }
        else if (currX > 0)
        {
            sr.flipX = false;
        }
    }
}
