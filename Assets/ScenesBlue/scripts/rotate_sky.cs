using UnityEngine;

public class rotate_sky : MonoBehaviour
{
   
   public float rotate_speed = 0.8f;

    void Update(){
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * rotate_speed);
    }
}
