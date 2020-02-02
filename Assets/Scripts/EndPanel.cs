using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndPanel : MonoBehaviour
{
	public GameObject canvas;
	public Image Background;


	public Image T0Scotch;
	public Image T1Bouton;

	public Image Tete0Bandage;
	public Image Tete1Bonnet;

	public Image B0BrosseADent;
	public Image B1BosseACheveux;

	public Image J0Maris;
	public Image J1Fourchette;
	private List<Image> _images;
	public void OnEndPanel(BotObject[] objects)
	{
		canvas.SetActive(true);
		StartCoroutine(OnEndPanelIEnumerator(objects));
	}
	public IEnumerator OnEndPanelIEnumerator(BotObject[] objects)
	{
		yield return null;
		List< BotObject > objectAslist = new List<BotObject>(objects);

		_images = new List<Image>();
		if (objectAslist.Contains(BotObject.BodyObject0))
		{
			_images.Add(T0Scotch);
		}
		if (objectAslist.Contains(BotObject.BodyObject1))
		{
			_images.Add(T1Bouton);
		}

		if (objectAslist.Contains(BotObject.HeadObject0))
		{
			_images.Add(Tete0Bandage);
		}
		if (objectAslist.Contains(BotObject.HeadObject1))
		{
			_images.Add(Tete1Bonnet);
		}

		if (objectAslist.Contains(BotObject.ArmObject0))
		{
			_images.Add(B0BrosseADent);
		}
		if (objectAslist.Contains(BotObject.ArmObject1))
		{
			_images.Add(B1BosseACheveux);
		}

		if (objectAslist.Contains(BotObject.LegObject0))
		{
			_images.Add(J0Maris);
		}
		if (objectAslist.Contains(BotObject.LegObject1))
		{
			_images.Add(J1Fourchette);
		}

		foreach (Image i in _images)
		{
			i.gameObject.SetActive(true);
		}
	}
}
