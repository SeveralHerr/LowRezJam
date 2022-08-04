using UnityEngine;

public class PlantRing : MonoBehaviour 
{
    public GameObject prefab;
    public float lifetime = .5f;

    public PlantRing Create(Vector2 initialPosition)
    {
        var newObject = Instantiate(prefab, initialPosition, Quaternion.identity) as GameObject;
        var obj = newObject.GetComponent<PlantRing>();
        return obj;
    }

    private void Update()
    {
        transform.position = Player.Instance.Position;
        lifetime -= Time.deltaTime;
        if(lifetime <= 0)
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

