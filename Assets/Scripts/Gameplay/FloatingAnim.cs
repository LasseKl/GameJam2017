using UnityEngine;

public class FloatingAnim : MonoBehaviour
{
    const float SPEED = 0.3f;

    public float maxY;
    public float minY;

    public bool goUp = false;

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + (goUp ? SPEED * Time.deltaTime : SPEED * -Time.deltaTime), transform.position.z);

        if (transform.position.y <= minY)
            goUp = true;
        if (transform.position.y >= maxY)
            goUp = false;
    }
}