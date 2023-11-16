using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpbarSystem : MonoBehaviour
{
    [SerializeField]
    HeroKnight palyer;

    [SerializeField]
    RectTransform hpbar;

    float widthOrigin;

    private void Awake()
    {
        widthOrigin = hpbar.rect.width;
        //Debug.Log(widthOrigin);
    }

    private void Update()
    {
        SetHpBar();
    }

    public void SetHpBar()
    {
        hpbar.sizeDelta = new Vector2((widthOrigin * ((float)palyer.CurHp / palyer.MaxHp)),hpbar.sizeDelta.y);
    }


}
