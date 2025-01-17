using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    float randomTime;
    float timer;
    public void onEnter(Enemy enemy)
    {
        Debug.Log("Idle");
        enemy.Stop();
        timer = 0;
        randomTime = Random.Range(4f, 7f);
    }

    public void OnExecute(Enemy enemy)
    {   
        timer += Time.deltaTime;
        if(timer < randomTime)
        {
            enemy.ChangeState(new PatrolState());
        }

        
    }

    public void OnExit(Enemy enemy)
    {
        
    }



}
