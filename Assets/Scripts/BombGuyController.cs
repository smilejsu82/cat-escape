using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombGuyController : MonoBehaviour
{
    [SerializeField] Transform flagTransform;

    //BombGuyController가 Animator컴포넌트를 알아야한다 
    //왜? 애니메이션 전환을 해야 하니깐 
    //Animator컴포넌트는 자식 오브젝트 anim에 붙어 있다 
    //어떻게 하면 자식오브젝트에 붙어 있는 Animator컴포넌트를 가져올수 있을까?
    [SerializeField] private Animator anim;

    private Coroutine coroutine;

    private void Awake()
    {
        Debug.Log("Awake");
    }

    private void OnEnable()
    {
        Debug.Log("Enable");
    }

    private void Start()
    {
        Debug.Log("Start");
        //Transform animTransform = this.transform.Find("anim");
        //GameObject animGo = animTransform.gameObject;
        //this.anim = animGo.GetComponent<Animator>();
        //코루틴 함수 호출시 
        this.coroutine = this.StartCoroutine(this.CoMove(() => {
            Debug.LogFormat("이동을 모두 완료 했습니다.");
        }));
    }


    IEnumerator CoMove(System.Action callback)
    {
        //매 프레임마다 앞으로 이동 
        while (true) {
            this.transform.Translate(transform.right * 1f * Time.deltaTime);
            float length = this.flagTransform.position.x - this.transform.position.x;
            Debug.LogFormat("이동중.. 남은거리  : {0}", length);
            if (length < 1)
            {
                break;  //while문을 벗어난다 
            }
            yield return null;//다음프레음으로 넘어간다
        }

        Debug.Log("이동완료");
        yield return null;
        yield return null;
        yield return null;
        yield return null;
        yield return null;
        yield return null;
        yield return null;
        yield return null;
        yield return null;
        yield return null;
        yield return null;
        yield return null;
        yield return null;
        Debug.Log("End Of CoMove");
        callback();
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //코루틴 멈추기 
            StopCoroutine(this.coroutine);
        }
        
        //if (Input.GetKeyDown(KeyCode.Alpha0))
        //{
        //    Debug.Log("Idle");
        //    //애니메이션 전환 하기 
        //    //전환 할때 파라미터에 값을 변경하기 
        //    this.anim.SetInteger("State", 0);
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha1))
        //{
        //    Debug.Log("Run");
        //    this.anim.SetInteger("State", 1);
        //}
    }
}
