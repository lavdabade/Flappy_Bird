using UnityEngine;

public class pipeSpawner : MonoBehaviour
{
    public float maxTime=1;
    public GameObject pipe;
    private float timer=0;
    // Update is called once per frame
    void Update()
    {
        if(timer >maxTime)  {
            GameObject newPipe = Instantiate(pipe);
            newPipe.transform.position = transform.position + new Vector3(0f, Random.Range(-2, 2), 0f);
            Destroy(newPipe, 3);
            timer = 0;
        }
        timer += Time.deltaTime;
    }
}
