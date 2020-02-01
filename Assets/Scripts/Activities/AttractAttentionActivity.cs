using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractAttentionActivity : Activity
{
    public Activity _onAttractAttentionActivity;
    public override bool canCancelActivity => true;
    public override void OnDone(Character chara)
    {
        base.OnDone(chara);
        this.enabled = false;
        if (_onAttractAttentionActivity != null)
        {
            _onAttractAttentionActivity.enabled = true;
        }
    }
    private void OnEnable()
    {
    }
}

