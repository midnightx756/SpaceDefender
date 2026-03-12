using UnityEngine;

public class SpriteScroller : MonoBehaviour
{
    [SerializeField] Vector2 moveSpeed;

    Vector2 offset;
    Material material;
    void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
        offset = new Vector2();
    }

    void Update()
    {
        offset = moveSpeed* Time.time;
        material.mainTextureOffset = offset;
    }
}
