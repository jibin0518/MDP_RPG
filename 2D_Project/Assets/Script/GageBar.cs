using UnityEngine;

public class GageBar : MonoBehaviour
{
    [SerializeField]
    Player player;

    [SerializeField]
    RectTransform bulletbar;

    float widthOrigin;

    private void Awake()
    {
        widthOrigin = bulletbar.rect.width;
    }

    private void Update()
    {
        SetBulletBar();
    }

    public void SetBulletBar()
    {
        bulletbar.sizeDelta = new Vector2((widthOrigin * (player.skillcnt/10)),bulletbar.sizeDelta.y);
    }
}
