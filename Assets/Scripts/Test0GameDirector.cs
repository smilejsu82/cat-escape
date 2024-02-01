using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test0GameDirector : MonoBehaviour
{
    [SerializeField] private CaptainController captainController;
    [SerializeField] private Text hpText;

    public void UpdateHpText(int hp, int maxHp)
    {
        this.hpText.text = string.Format("{0}/{1}", hp, maxHp);
    }
}
