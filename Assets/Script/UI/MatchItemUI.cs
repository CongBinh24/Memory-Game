using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatchItemUI : MonoBehaviour
{
    private int m_id;
    public Sprite bg;
    public Sprite backBG;
    public Image itemBG;
    public Image itemIcon;
    public Button btnComp;
    private bool m_isOpend; // trạng thái đang mở hay úp
    private Animator m_anim;

    public int Id { get => m_id; set => m_id = value; }

    private void Awake()
    {
        m_anim = GetComponent<Animator>();
    }

    public void UpdateFirstState(Sprite icon)// gán hình ảnh
    {
        if(itemBG)
            itemBG.sprite = backBG; // ban đầu úp mặt sau 

        if (itemIcon)
        {
            itemIcon.sprite = icon; // gán icon 
            itemIcon.gameObject.SetActive(false); // nhưng ẩn đi, check hoàn thành game
        }
    }

    public void ChangeState()
    {
        m_isOpend = !m_isOpend;

        if(itemBG)
            itemBG.sprite = m_isOpend ? bg : backBG; // mở → bg, úp → backBG

        if (itemIcon)
            itemIcon.gameObject.SetActive(m_isOpend); // khi mở thì hiện icon
    }

    public void OpenAnimTrigger() // lật lá 
    {
        if (m_anim)
            m_anim.SetBool(AnimState.Flip.ToString(), true);
    }

    public void ExplodeAnimTrigger() // biến mất khi đúng
    {
        if (m_anim)
            m_anim.SetBool(AnimState.Explode.ToString(), true);
    }

    public void BackToIdle() // trở lại úp khi sai
    {
        if (m_anim)
            m_anim.SetBool(AnimState.Flip.ToString(), false);

        if (btnComp)
            btnComp.enabled = !m_isOpend; // nếu lá còn úp thì cho click lại
    }


}
