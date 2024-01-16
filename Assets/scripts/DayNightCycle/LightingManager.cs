using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class LightingManager : MonoBehaviour
{
    //Refrences
    [SerializeField] private Light DirectionalLight;
    [SerializeField] private LightingPreset Preset;
    //Variables
    [SerializeField, Range(0, 1200)] private float TimeOfDay;
    [SerializeField, Range(0, 1200)] private float onStartTime;

    private void Start()
    {
        TimeOfDay = onStartTime;
    }
    private void Update()
    {
        if (Preset == null)
            return;

        if (Application.isPlaying)
        {
            TimeOfDay += Time.fixedDeltaTime;
            TimeOfDay %= 1200; //Clamp between 0-24
            UpdateLighting(TimeOfDay / 1200f);
        }
        else
        {
            UpdateLighting(TimeOfDay / 1200f);    
        }

    }

    private void UpdateLighting(float timePrecent)
    {

        RenderSettings.ambientLight = Preset.AmbientColour.Evaluate(timePrecent);
        RenderSettings.fogColor = Preset.FogColour.Evaluate(timePrecent);

        if (DirectionalLight != null)
        {
            DirectionalLight.color = Preset.DirectionalColour.Evaluate(timePrecent);
            DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePrecent * 360f)-90f, -145f, 0));
        }

    }

    private void OnValidate()
    {
        if (DirectionalLight != null)
            return;

        if (RenderSettings.sun != null)
        {
            DirectionalLight = RenderSettings.sun;
        }
        else
        {
            Light[] lights = GameObject.FindObjectsOfType<Light>();
            foreach (Light light in lights)
            {
                if (light.type == LightType.Directional)
                {
                    DirectionalLight = light;
                    return;
                }
            }
        }
    }

}
