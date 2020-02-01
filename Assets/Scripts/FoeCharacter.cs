using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoeCharacter : Character
{
    public bool randomActivities = true;
    int _orderedActivityIndex = 0;
    public List<Activity> randomPossibleActivities;
    public List<Activity> orderedPossibleActivities;
    public override void OnActivityFinished(Activity activity)
    {
        if (randomActivities)
        {
            SetNextRandomActivity(activity);
        }
        else
        {
            SetNextOrderedActivity(activity);
        }
    }
    private void SetNextRandomActivity(Activity last)
    {
        if (randomPossibleActivities.Count > 1)
        {
            bool selected = false;
            while (!selected)
            {
                int i = Random.Range(0,randomPossibleActivities.Count);
                if (randomPossibleActivities[i] != last)
                {
                    SetCurrentActivity(randomPossibleActivities[i]);
                    selected = true;
                }
            }
        }
        else if (randomPossibleActivities.Count == 1)
        {
            SetCurrentActivity(randomPossibleActivities[0]);
        }
    }

    private void SetNextOrderedActivity(Activity last)
    {
        int activityToDo = _orderedActivityIndex;
        _orderedActivityIndex = ((_orderedActivityIndex + 1) % orderedPossibleActivities.Count);

        SetCurrentActivity(orderedPossibleActivities[activityToDo]);
    }

    private void Start()
    {
        OnActivityFinished(null);
    }
    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    public virtual void OnDetectedHazardousActivity(Activity activity)
    {
        if (_currentActivity != null)
        {
            if (activityReached)
            {
                if (_currentActivity.canCancelActivity)
                {
                    _currentActivity.OnActivityCanceled(this);
                }
                else
                {
                    return;
                }
            }
        }
        SetCurrentActivity(activity);
    }
}
