using UnityEngine;

public class HpBar: MonoBehaviour
{
    [SerializeField]
    Player palyer;

    [SerializeField]
    RectTransform hpbar;

    float widthOrigin;

    private void Awake()
    {
        widthOrigin = hpbar.rect.width;
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
