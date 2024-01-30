using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CatEscapeGameDirector gameDirector;
    [SerializeField] private Button btnLeft;
    [SerializeField] private Button btnRight;

    public float radius = 1f;

    public int maxHp = 13;
    public int hp;

    private void Awake()
    {
        this.hp = this.maxHp;
        Debug.LogFormat("<color=yellow>{0}/{1}</color>", this.hp, this.maxHp);
    }

    private void Start()
    {
        //this.btnLeft.onClick.AddListener(this.LeftButtonClick);
        //this.btnRight.onClick.AddListener(this.RightButtonClick);

        this.btnLeft.onClick.AddListener(() => {
            Debug.Log("왼쪽 화살표 버튼 클릭");
            this.transform.Translate(-2, 0, 0);
        });
        this.btnRight.onClick.AddListener(() => {
            Debug.Log("오른쪽 화살표 버튼 클릭");
            this.transform.Translate(2, 0, 0);
        });

    }

    void Update()
    {
        if (gameDirector.isGameOver) return;

        //키보드 입력을 받는 코드 작성 
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Debug.Log("왼쪽으로 2유닛만큼 이동");
            //X 축으로-2만큼 이동 
            this.transform.Translate(-2, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Debug.Log("오른쪽으로 2유닛만큼 이동");
            //X축으로 2만큼 이동 
            this.transform.Translate(2, 0, 0);
        }

        float clampX = Mathf.Clamp(this.transform.position.x, -8.13f, 8.13f);
        Vector3 pos = this.transform.position;
        pos.x = clampX;
        this.transform.position = pos;
    }

    //이벤트 함수 
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, this.radius);
    }

    public void LeftButtonClick()
    {
        Debug.Log("Left Button Clicked!");
    }

    public void RightButtonClick()
    {
        Debug.Log("Right Button Clicked!");
    }
}
