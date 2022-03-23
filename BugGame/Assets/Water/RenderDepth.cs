using UnityEngine;

[ExecuteInEditMode]

public class RenderDepth : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        GetComponent<Camera>().depthTextureMode = DepthTextureMode.DepthNormals;
    }
}
