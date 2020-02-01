using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GainItemActivity : Activity
{
	[SerializeField]private BotObject botPart;
	public override void OnDone(Character chara)
	{
		base.OnDone(chara);
		PlayerCharacter pc = (PlayerCharacter)chara;
		if (pc != null)
		{
			pc.AddItem(botPart);
		}
	}

	
}
