using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToActivity : Activity
{
    public override void OnReached(Character chara)
    {
        StartCoroutine(CallDone(imobilizeSeconds, chara));
    }
    public override void OnDone(Character chara)
    {
        chara.OnActivityFinished(this);
    }
    IEnumerator CallDone(float wait, Character chara)
    {
        if (wait > 0f)
        {
            yield return new WaitForSeconds(wait);
        }
        OnDone(chara);
    }
}
