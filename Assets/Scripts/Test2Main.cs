using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2Main : MonoBehaviour
{
    [SerializeField] private Transform basketTransform;

    void Update()
    {
        //화면을 클릭하면 
        if (Input.GetMouseButtonDown(0))
        {
            //픽셀 좌표를 가지고 월드안에서 레이 객체를 만든다 
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //레이 객체가 가지고있는속성 
            // ray.origin : 시작 위치 
            // ray.direction : 방향 
            //눈으로 레이 보기 
                            //시작위치    방향         색상    몇초동안 보여줄래
            Debug.DrawRay(ray.origin, ray.direction * 20f, Color.red, 10);

            // 레이와 콜라이더 충돌 체크 
            RaycastHit hit; //충돌 했다면 충돌 정보를 담는 변수 

            if (Physics.Raycast(ray.origin, ray.direction, out hit, 20))
            {
                //레이와 콜라이더가 충돌 했다
                Debug.Log("충돌함");
                Debug.LogFormat("=> {0}", hit.point); //충돌 지점위치 (월드위치)
                //this.cubeTransform.position = hit.point;

                int x = Mathf.RoundToInt(hit.point.x);
                int z = Mathf.RoundToInt(hit.point.z);
                Debug.LogFormat("=> {0}", new Vector3(x, hit.point.y, z));

                basketTransform.position = new Vector3(x, hit.point.y, z);
            }

        }
    }
}
