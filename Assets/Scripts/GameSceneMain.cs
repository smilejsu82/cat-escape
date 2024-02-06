using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSceneMain : MonoBehaviour
{
    [SerializeField] private Text textHp;
    [SerializeField] private Button btnLoadScene;
    [SerializeField] private GameObject heroPrefab;
    [SerializeField] private GameManager heroDataManager;
    void Start()
    {
        //��ư�� Ŭ���ϸ� ���ٹ��� ȣ��� 
        this.btnLoadScene.onClick.AddListener(() => {
            Debug.Log("VillegeScene���� ��ȯ");
            SceneManager.LoadScene("VillegeScene");
        });

        this.CreateHero();
    }

    private void CreateHero()
    {
        GameObject heroGo = Instantiate(this.heroPrefab);
        Debug.LogFormat("heroGo: {0}", heroGo);
        HeroController heroController = heroGo.GetComponent<HeroController>();

        heroController.onHit = () => {

            Debug.Log("������ ���ظ� �޾ҽ��ϴ�.");
            Debug.LogFormat("{0}/{1}", heroController.Hp, heroController.MaxHp);

            GameManager.heroHp = heroController.Hp;
            GameManager.heroMaxHp = heroController.MaxHp;

            this.textHp.text = string.Format("{0}/{1}", heroController.Hp, heroController.MaxHp);
        };
    }
}
