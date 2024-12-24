using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState 
{
    void onEnter(Enemy enemy);

    void OnExit(Enemy enemy);

    void OnExecute(Enemy enemy);
}
