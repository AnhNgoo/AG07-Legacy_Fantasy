using Unity.VisualScripting;
using UnityEngine;

public class BG_Loop : MonoBehaviour
{
    [SerializeField] Transform Cam;
    [SerializeField] Transform player;
    [SerializeField] float distance;
    [SerializeField] SpriteRenderer[] BG;
    Vector3 movement = Vector3.zero;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 BGposition = this.transform.position;
        BGposition.y = Cam.position.y;
        this.transform.position = BGposition;
        movement.x = Input.GetAxisRaw("Horizontal");
        for (int i = 0; i < BG.Length; i++)
        {
            BG[i].transform.Translate(movement * (-i) * Time.deltaTime);
            if (Mathf.Abs(player.transform.position.x - BG[i].transform.position.x) >= distance)
            {
                Vector3 _BGposition = BG[i].transform.position;
                _BGposition.x = player.transform.position.x;
                BG[i].transform.position = _BGposition;
            }
        }
    }
}