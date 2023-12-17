using UnityEngine;

public class BossHp : MonoBehaviour
{
    [SerializeField]
    Boss boss;

    [SerializeField]
    RectTransform bossbar;

    float widthOrigin;
    void Start()
    {
        widthOrigin = bossbar.rect.width;
    }

    // Update is called once per frame
    void Update()
    {
        SetHpBar();
    }

    public void SetHpBar()
    {
        bossbar.sizeDelta = new Vector2((widthOrigin * ((float)boss.curhp / boss.maxhp)), bossbar.sizeDelta.y);
    }
}
