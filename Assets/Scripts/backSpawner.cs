using UnityEngine;

public class backSpawner : MonoBehaviour
{
    public GameObject backImage;
    void Update()  {
        if(backImage.transform.position.x < -20.85)   {
            backImage.transform.position = new Vector3(23.85f, 0f, 0f);
        }
    }
}