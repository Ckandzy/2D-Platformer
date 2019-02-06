using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class BreakablePlatform : MonoBehaviour
{
    protected Animator m_Animator;
    protected BoxCollider2D m_Boxcollider2D;
    protected SpriteRenderer m_SpriteRender;
    public float breakDelay = 2f;

    protected readonly int m_HashBreakPara = Animator.StringToHash("Break");
    // Start is called before the first frame update

    private void Awake()
    {
        m_Animator = GetComponent<Animator>();
        m_Boxcollider2D = GetComponent<BoxCollider2D>();
        m_SpriteRender = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Break()
    {
        yield return new WaitForSeconds(breakDelay);
        m_Animator.SetTrigger(m_HashBreakPara);
        m_Boxcollider2D.enabled = false;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            StartCoroutine(Break());
    }

    public void WakeUp()
    {
        m_Boxcollider2D.enabled = true;
        //m_Animator.ResetTrigger(m_HashBreakPara);
        //m_Animator.Play("Normal", -1, 0f);
        //m_SpriteRender.enabled = true;
        //Debug.Log(m_SpriteRender.enabled);
    }
}
