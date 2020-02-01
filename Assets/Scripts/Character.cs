﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
[RequireComponent(typeof(ThirdPersonCharacter))]
public abstract class Character : MonoBehaviour
{
    protected GoToActivity _personalGoToActivity;
    protected NavMeshAgent _navMeshAgent;
    protected ThirdPersonCharacter _character;
    public Transform target; // target to aim for

    public Activity _currentActivity { get; protected set; }
    public bool activityReached { get; protected set; } = false;


    protected virtual void Awake()
    {
        _personalGoToActivity = new GameObject("Target for " + this.gameObject.name).AddComponent<GoToActivity>();
        _personalGoToActivity.imobilizeSeconds = 0f;

        _navMeshAgent = GetComponent<NavMeshAgent>();
        _character = GetComponent<ThirdPersonCharacter>();
        _navMeshAgent.updateRotation = false;
        _navMeshAgent.updatePosition = true;
    }

    protected virtual void Update()
    {
        HandleActivity();
    }
    public virtual void HandleActivity()
    {
        if (_currentActivity != null)
        {
            if (!activityReached)
            {
                _navMeshAgent.SetDestination(_currentActivity.positionTarget.position);


                if (_navMeshAgent.remainingDistance > _navMeshAgent.stoppingDistance)
                {
                    //We continue moving
                    _character.Move(_navMeshAgent.desiredVelocity, false, false);
                }
                else
                {
                    //We arrived
                    _character.Move(Vector3.zero, false, false);
                    activityReached = true;
                    _currentActivity.OnReached(this);
                }
            }
        }
    } 
    public void GoToPosition(Vector3 worldPosition)
    {
        _personalGoToActivity.transform.position = worldPosition;
        SetCurrentActivity(_personalGoToActivity);
    }

    public virtual void SetCurrentActivity(Activity activity)
    {
        _currentActivity = activity;
        activityReached = false;
    }
    public abstract void OnActivityFinished(Activity activity);
}
