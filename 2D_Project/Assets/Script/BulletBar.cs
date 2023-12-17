using UnityEngine;

public class BulletBar: MonoBehaviour
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
        bulletbar.sizeDelta = new Vector2((widthOrigin * ((float)player.curbullet/player.maxbullet)),bulletbar.sizeDelta.y);
    }
}
