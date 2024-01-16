using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class openwebsite : MonoBehaviour
{
    // Start is called before the first frame update
    public void openweb()
    {
        Application.OpenURL((Application.streamingAssetsPath) + ("Assets/StreamingAssets/local_www/inde.html"));
    }

}
