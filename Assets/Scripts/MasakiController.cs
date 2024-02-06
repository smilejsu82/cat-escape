using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasakiController : MonoBehaviour
{
    private Coroutine coroutine;

    void Update()
    {
        //화면을 클릭하면 Ray를 만든다 
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 20, Color.red, 5);

            //레이와 콜라이더 충돌 체크
            RaycastHit hit;
            if (Physics.Raycast(ray.origin, ray.direction, out hit, 20))
            {
                //충돌체크 되면 충돌 정보 얻어오기 
                Vector3 tpos = this.transform.position;
                tpos.x = hit.point.x;
                tpos.y = 0;
                tpos.z = hit.point.z;

                Debug.Log(tpos);    //목표 위치 
                //this.transform.position = tpos;

                //코루틴 
                if (this.coroutine != null)
                    StopCoroutine(this.coroutine);

                this.coroutine = StartCoroutine(this.CoMove(tpos));
            }
        }
    }

    IEnumerator CoMove(Vector3 tpos)
    {
        this.transform.LookAt(tpos);    //바라본다 
        while (true)
        {
            this.transform.Translate(Vector3.forward * 1f * Time.deltaTime);
            float distance = (tpos - this.transform.position).magnitude;
            Debug.LogFormat("distance: {0}", distance);
            if (distance <= 0.1f) {
                break;
            }
            yield return null;
        }
        Debug.Log("이동완료");
    }
}
