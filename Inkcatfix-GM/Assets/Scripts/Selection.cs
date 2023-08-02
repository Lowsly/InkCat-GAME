using UnityEngine;
using UnityEngine.UI;

public class Selection : MonoBehaviour
{
    [SerializeField] private RectTransform[] options;
    [SerializeField] private AudioClip changeSound;
    [SerializeField] private AudioClip interactSound;
    private AudioSource audioSource;
    private RectTransform rect;
    private int currentPosition;

    private void Awake()
    {
            rect = GetComponent<RectTransform>();
            audioSource = gameObject.AddComponent<AudioSource>();
    }


    private void Update()
{
    if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        ChangePosition(-1);
    else if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        ChangePosition(1);

        if(Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.E))
            Interact();
}

    private void Interact()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.E))
            {
                audioSource.clip = interactSound;
                audioSource.Play();
                
                options[currentPosition].GetComponent<Button>().onClick.Invoke();
            }
            
    }

    private void ChangePosition(int _change)

    {
        currentPosition += _change;

        if(_change != 0)
        {
            audioSource.clip = changeSound;
            audioSource.Play();
        }
        if (currentPosition <0)
            currentPosition = options.Length -1;
        else if (currentPosition > options.Length -1)
            currentPosition = 0;

        rect.position = new Vector3(rect.position.x, options[currentPosition].position.y, 0);
    }

    
}
