using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatEscapeGameDirector : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    public Image hpGauge;
    public bool isGameOver = false;

    public void DecreaseHp()
    {
        if (this.isGameOver) return;

        float percent = (float)this.playerController.hp / this.playerController.maxHp;

        Debug.LogFormat("<color=yellow>{0}/{1} -> {2}%</color>", this.playerController.hp, this.playerController.maxHp, percent);

        this.hpGauge.fillAmount = percent;

        if (this.hpGauge.fillAmount <= 0) {
            this.isGameOver = true;
        }
    }
}
