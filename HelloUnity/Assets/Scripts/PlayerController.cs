using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CatEscapeGameDirector gameDirector;

    public float radius = 1f;

    public int maxHp = 13;
    public int hp;

    private void Awake()
    {
        this.hp = this.maxHp;
        Debug.LogFormat("<color=yellow>{0}/{1}</color>", this.hp, this.maxHp);
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
}
