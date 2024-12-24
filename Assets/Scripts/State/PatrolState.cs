using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IState
{ 
    float randomTime;
    float timer;
    bool dir;
    public void onEnter(Enemy enemy)
    {
        Debug.Log("Patrol");
        timer = 0f;
        dir = true;
        randomTime = Random.Range(2f, 4f);
    }

    public void OnExecute(Enemy enemy)
    {   timer += Time.deltaTime;
        Debug.Log(1);
        if(timer < randomTime)
        {
            enemy.MovingTo();
        }else
        {
            enemy.ChangeState(new IdleState());
        }
        if (timer > randomTime / 2)
        {
                enemy.transform.rotation = Quaternion.Euler(new Vector3(0, dir ? 0 : 180, 0));
            dir = !dir;
        }

        
    }

    public void OnExit(Enemy enemy)
    {
        
    }


}
