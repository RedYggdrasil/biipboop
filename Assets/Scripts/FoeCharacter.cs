using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoeCharacter : Character
{
    public List<Activity> possibleActivities;
    public override void OnActivityFinished(Activity activity)
    {
        bool selected = false;
        while (!selected)
        {
            int i = Random.Range(0,possibleActivities.Count);
            if (possibleActivities[i] != activity)
            {
                SetCurrentActivity(possibleActivities[i]);
                selected = true;
            }
        }

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
}
