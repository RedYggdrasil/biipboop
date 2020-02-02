using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class DebugNoiseCube : MonoBehaviour
{
    public Activity canInteractActivity;
    public Activity noiseActivity;

    public Material canInteractMaterial;
    public Material noiseMaterial;

    private Activity _currentActivity;

    private Renderer _activeRenderer;
    private void Awake()
    {
        _currentActivity = ((canInteractActivity.enabled) ? canInteractActivity : noiseActivity);
        _activeRenderer = GetComponent<Renderer>();
        _activeRenderer.material = ((canInteractActivity.enabled) ? canInteractMaterial : noiseMaterial);
    }

    // Update is called once per frame
    void Update()
    {
        if (canInteractActivity.enabled != (_currentActivity == canInteractActivity))
        {
            _currentActivity = ((canInteractActivity.enabled) ? _currentActivity : noiseActivity);
            _activeRenderer.material = ((canInteractActivity.enabled) ? canInteractMaterial : noiseMaterial);

            if (canInteractActivity.enabled)
            {
                AudioManager.instance.Stop("TV music");
                AudioManager.instance.Play("TV off");
            }
            else
            {
                AudioManager.instance.Play("TV music");
            }
        }
    }
}
