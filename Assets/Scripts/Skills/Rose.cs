using UnityEngine;

public class Rose : MonoBehaviour
{
    public GameObject prefab;
    public float lifetime = 2f;

    public Rose Create()
    {
        var spawnY = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
        var spawnX = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);

        var spawnPosition = new Vector2(spawnX, spawnY);

        var newObject = Instantiate(prefab, spawnPosition, Quaternion.identity) as GameObject;
        var obj = newObject.GetComponent<Rose>();
        return obj;
    }

    private void Update()
    {
        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Score.Instance.currentScore += 1;
            Destroy(collision.gameObject);
        }
    }
}

