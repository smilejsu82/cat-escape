using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VillegeSceneMain : MonoBehaviour
{
    [SerializeField] private Text heroHpText;
    void Start()
    {
        Debug.LogFormat("VillegeSceneMain: <color=yellow>{0}/{1}</color>", GameManager.heroHp, GameManager.heroMaxHp);
        this.heroHpText.text = string.Format("{0}/{1}", GameManager.heroHp, GameManager.heroMaxHp);
    }
}
