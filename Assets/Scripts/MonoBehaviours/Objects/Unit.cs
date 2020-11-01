using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : PlayerObject {

    public TaskList tasks = new TaskList();

    public List<Ability> abilities;

    public Unit()
    {
        _type = RTSObjectType.Unit;
    }

    void Update()
    {
        PerformTasks();
    }

    public virtual void PerformTasks() 
    {
        Task task = tasks.GetTask();
        if(task == null) return;

        Ability ability = GetAbility(task);

        if(ability != null) {
            ability.PerformTask(task);
        }
        else {
            tasks.FinishTask();
        }
    }

    public Ability GetAbility(Task task) 
    {
        foreach(Ability ability in abilities) {
            if(task.GetTaskType() == ability.taskType) {
                return ability;
            }
        }

        return null;
    }

    public bool HasAbility(Task task) 
    {
        foreach(Ability ability in abilities) {
            if(task.GetTaskType() == ability.taskType) {
                return true;
            }
        }

        return false;
    }
}