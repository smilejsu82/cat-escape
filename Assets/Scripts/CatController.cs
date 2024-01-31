using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rbody;
    [SerializeField] private float moveForce = 100f;
    [SerializeField] private float jumpForce = 680f;

    [SerializeField]
    private ClimbCloudGameDirector gameDirector;

    private Animator anim;

    private void Start()
    {
        //this.gameObject.GetComponent<Animation>();

        anim = GetComponent<Animator>();

        //this.gameDirector = GameObject.Find("GameDirector").GetComponent<ClimbCloudGameDirector>();
        //this.gameDirector = GameObject.FindAnyObjectByType<ClimbCloudGameDirector>();
    }

    void Update()
    {
        //스페이스바를 누르면 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //힘을 가한다 
            this.rbody.AddForce(this.transform.up * this.jumpForce);
            //this.rbody.AddForce(Vector3.up * this.force);
        }

        // -1, 0, 1 : 방향 
        int dirX = 0;
        //왼쪽화살표키를 누르고 있는 동안에 
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            dirX = -1;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            dirX = 1;
        }

        //Debug.Log(dirX); //방향 -1, 0, 1

        //스케일 X를 변경 하는데 키가 눌렸을 때만 
        //키가 눌렸을때만 = (dirX != 0)
        if (dirX != 0) {
            this.transform.localScale = new Vector3(dirX, 1, 1);
        }
        

        //벡터의 곱 
        //Debug.Log(this.transform.right * dirX);  //벡터3

        //도전 ! : 속도를 제한하자 
        //velocity.x 가 3정도가 넘어가니깐 빨라지는거 같드라구...
        if (Mathf.Abs(this.rbody.velocity.x) < 3)
        {
            this.rbody.AddForce(this.transform.right * dirX * moveForce);
        }

        this.anim.speed = (Mathf.Abs(this.rbody.velocity.x) / 2f);
        this.gameDirector.UpdateVelocityText(this.rbody.velocity);
        this.gameDirector.UpdateIsJumpingText(this.rbody.velocity);
    }

    //Trigger모드일경우 충돌 판정을 해주는 이벤트 함수 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //최초 충돌 할때 한번만 호출 
        Debug.LogFormat("OnTriggerEnter2D: {0}", collision);

        //장면을 전환 
        SceneManager.LoadScene("ClimbCloudClear");
    }
}
