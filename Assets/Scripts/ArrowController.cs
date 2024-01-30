using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float radius = 1f;
    [SerializeField] private int damage = 1;

    //동적으로 생성되는 애는 씬에 있는거 Assign 할수 없다 
    private CatEscapeGameDirector gameDirector;

    private GameObject playerGo;

    private void Start()
    {
        //이름으로 게임오브젝트를 찾는다 
        this.playerGo = GameObject.Find("player");

        //타입으로 컴포넌트를 찾는다 
        this.gameDirector = GameObject.FindObjectOfType<CatEscapeGameDirector>();
    }

    void Update()
    {
        //방향 * 속도 * 시간 
        Vector3 movement = Vector3.down * speed * Time.deltaTime;
        this.transform.Translate(movement);
        //Debug.LogFormat("y : {0}", this.transform.position.y);

        //현재 y 좌표가 2.93보다 작아졌을때 씬에서 제거한다 
        if (this.transform.position.y <= -2.93f)
        {
            //Debug.LogError("제거!");
            //Destroy(this);  // ArrowController 컴포넌트가 제거 된다
            Destroy(this.gameObject);   //게임오브젝트를 씬에서 제거 
        }

        //거리 
        Vector2 p1 = this.transform.position;
        Vector2 p2 = this.playerGo.transform.position;
        Vector2 dir = p1 - p2;//방향 
        float distance = dir.magnitude; //거리 
        //float distance = Vector2.Distance(p1, p2);

        float r1 = this.radius;
        PlayerController controller = this.playerGo.GetComponent<PlayerController>();
        float r2 = controller.radius;
        float sumRadius = r1 + r2;

        if (distance < sumRadius)   //충돌함
        {
            Debug.LogFormat("충돌함: {0}, {1}", distance, sumRadius);
            Destroy(this.gameObject);   //씬에서 제거 

            controller.hp -= this.damage;
            if (controller.hp <= 0) controller.hp = 0;

            this.gameDirector.DecreaseHp();
        }

    }

    //이벤트 함수 
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, this.radius);
    }
}
