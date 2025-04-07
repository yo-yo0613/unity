using UnityEngine;

public class FireflyMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float directionChangeInterval = 2f;
    public float borderPadding = 100f; // 邊界延伸量（像素）

    private Vector3 direction;
    private float timer;

    void Start()
    {
        PickRandomDirection();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= directionChangeInterval)
        {
            PickRandomDirection();
            timer = 0f;
        }

        transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);

        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);

        // 邊界反彈（延伸一些容忍距離）
        if (screenPos.x < -borderPadding || screenPos.x > Screen.width + borderPadding)
        {
            direction.x *= -1;
        }

        if (screenPos.y < -borderPadding || screenPos.y > Screen.height + borderPadding)
        {
            direction.y *= -1;
        }
    }

    void PickRandomDirection()
    {
        direction = new Vector3(
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f),
            0f
        ).normalized;
    }
}
