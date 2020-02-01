using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedNoiseActivity : Activity
{
    public Activity _onFixedActivity;
    public List<FoeCharacter> foeCharacters;
    public float noiseDistance = 10f;

    public override bool canCancelActivity => false;
    public override bool playerInteractibleActivity => false;
    public override void OnActivityCanceled(Character chara)
    {
        throw new System.NotImplementedException();
    }
    public override void OnReached(Character chara)
    {
        base.OnReached(chara);
        foreach (FoeCharacter foeCharacter in foeCharacters)
        {
            if (foeCharacter != chara && foeCharacter._currentActivity == this)
            {
                foeCharacter.OnActivityFinished(this);
            }
        }
    }

    public override void OnDone(Character chara)
    {
        base.OnDone(chara);
        this.enabled = false;
        if (_onFixedActivity != null)
        {
            _onFixedActivity.enabled = true;
        }
    }

    protected override void Awake()
    {
        base.Awake();
        foeCharacters = new List<FoeCharacter>(FindObjectsOfType<FoeCharacter>());
    }
    private void OnEnable()
    {
        for (int i = 0; i < foeCharacters.Count; ++i)
        {
            FoeCharacter foeCharacter = foeCharacters[i];
            if ((foeCharacter.transform.position - this.transform.position).magnitude < noiseDistance)
            {
                foeCharacter.OnDetectedHazardousActivity(this);
            }
        }
    }

}
