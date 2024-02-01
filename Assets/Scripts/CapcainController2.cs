using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapcainController2 : MonoBehaviour
{
    public enum State
    {

        Idle, Hit, Die
    }

    [SerializeField] private Animator anim;
    [SerializeField] private Test0GameDirector gameDirector;

    private float hitAnimLength = 0.133f;
    private float dieAnimLength = 0.133f;

    private State state;
    private int maxHp = 2;
    private int hp;

    private Coroutine coroutine;

    private void Start()
    {
        this.hp = this.maxHp;
        Debug.LogFormat("{0}/{1}", this.hp, this.maxHp);
        this.gameDirector.UpdateHpText(this.hp, this.maxHp);
        this.SetState(State.Idle);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.hp -= 1;
            Debug.LogFormat("{0}/{1}", this.hp, this.maxHp);
            this.gameDirector.UpdateHpText(this.hp, this.maxHp);
            this.SetState(State.Hit);
        }
    }

    private void SetState(State state)
    {
        if (this.state != state)
        {
            this.state = state;
            this.anim.SetInteger("State", (int)this.state);

            switch (this.state) {
                case State.Idle:
                    break;
                case State.Hit:
                    this.coroutine = this.StartCoroutine(this.CoHit());
                    break;
                case State.Die:
                    this.coroutine = this.StartCoroutine(this.CoDie());
                    break;
            }
            
        }
    }

    private IEnumerator CoHit()
    {
        yield return new WaitForSeconds(this.hitAnimLength);

        if (this.hp <= 0)
            this.SetState(State.Die);
        else
            this.SetState(State.Idle);
    }

    private IEnumerator CoDie()
    {
        yield return new WaitForSeconds(this.dieAnimLength);

        Destroy(this.gameObject);
    }
}
