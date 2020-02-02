using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInGame : MonoBehaviour
{
    private static UIInGame _instance;
    public static UIInGame instance
    {
        get
        {
            return _instance;
        }
    }
    private void Awake()
    {
        _instance = this;
    }
    [SerializeField] private Image _image1;
    [SerializeField] private Image _image2;

    [SerializeField] private SpriteContainer[] _sprites;

    public void OnEnterStep(int stepIndex)
    {
        _image1.sprite = _sprites[stepIndex].sprite1;
        _image2.sprite = _sprites[stepIndex].sprite2;
    }
}

[System.Serializable]
public class SpriteContainer
{
    public Sprite sprite1;
    public Sprite sprite2;
}