using UnityEngine;

public class PlayerTrail : MonoBehaviour
{
    [SerializeField] private GameObject _rightTrail;
    [SerializeField] private GameObject _leftTrail;

    private void Start()
    {
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            _rightTrail.SetActive(false);
            _leftTrail.SetActive(false);
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D) ||
                 Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            _rightTrail.SetActive(true);
            _leftTrail.SetActive(true);
        }
    }
}