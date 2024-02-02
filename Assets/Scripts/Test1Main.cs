using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test1Main : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //화면을 터치 하면 마우스 위치를 출력한다 
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(Input.mousePosition);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //시작위치      방향          색생      몇초동안 보여줌
            //Debug.DrawRay(ray.origin, ray.direction, Color.red, 10f);

            DrawArrow.ForDebug(ray.origin, ray.direction, 10, Color.red, ArrowType.Solid);
        }
    }
}
