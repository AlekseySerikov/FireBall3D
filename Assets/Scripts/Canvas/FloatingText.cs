using UnityEngine;

public class FloatingText : MonoBehaviour
{
    private bool _isScalingDown = false;

    void Start()
    {
        transform.localScale = new Vector3(0, 0, transform.localScale.z);
    }

    void Update()
    {

        if (_isScalingDown)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.localScale += new Vector3(2, 2, 0) * Time.deltaTime * 1.5f;
            transform.rotation = Quaternion.Euler(60, 0, 0);
            if (transform.localScale.x >= 0.75f)
            {
                _isScalingDown = true;
            }
        }
    }

    public void UpdateText(string text, Color color)
    {
        GetComponent<TextMesh>().text = text;
        GetComponent<TextMesh>().color = color;
    }
}