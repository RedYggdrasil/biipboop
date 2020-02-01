using System.Collections;
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

    public Activity _currentActivity;
    public bool activityReached = false;


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
                else if ((this.transform.position - _currentActivity.positionTarget.position).magnitude <= 1f/*_navMeshAgent.stoppingDistance*/)
                {
                    //We arrived
                    Debug.Log("here" + _currentActivity.gameObject.name);
                    _character.Move(Vector3.zero, false, false);
                    activityReached = true;
                    _currentActivity.OnReached(this);
                }
            }
            else
            {
                //We arrived
                _character.Move(Vector3.zero, false, false);
            }
        }
        else
        {
            _character.Move(Vector3.zero, false, false);
        }
    } 
    public void GoToPosition(Vector3 worldPosition)
    {
        _personalGoToActivity.transform.position = worldPosition;
        SetCurrentActivity(_personalGoToActivity);
    }

    public virtual void SetCurrentActivity(Activity activity)
    {
        if (_currentActivity == activity)
        {
            return;
        }
        if (_currentActivity != null)
        {
            if (_currentActivity.canCancelActivity)
            {
                if (activityReached)
                {
                    _currentActivity.OnActivityCanceled(this);
                }
            }
            _currentActivity = null;
        }
        _currentActivity = activity;
        activityReached = false;
    }
    public virtual void OnActivityFinished(Activity activity)
    {
        Debug.LogWarning("OnActivityFinished for " + this.gameObject.name + " activity " + ((activity != null) ? activity.gameObject.name:"null"));
        if (_currentActivity == activity)
        {
            _currentActivity = null;
            activityReached = false;
        }
    }
}
