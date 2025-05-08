using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AsteroidsUI : MonoBehaviour
{
    [SerializeField] HealthObject_Asteroids player;

    [SerializeField] TMP_Text hpText;
    [SerializeField] Image hpIcon;
    [SerializeField] Gradient hpColor;

    [SerializeField] TMP_Text moneyText;
    [SerializeField] Image moneyIcon;

    void Update()
    {
        float hp = player.GetHP();
        float startHp = player.GetStartHp();
        float hpRate = hp / startHp;

        hpText.text = Mathf.CeilToInt(player.GetHP()).ToString() + " HP";
        hpIcon.color = hpColor.Evaluate(hpRate);
    }
}
