using UnityEngine;
using UnityEngine.UI;

public class SelectionAbility : MonoBehaviour
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
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float VerticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetButtonDown("Horizontal"))
        {
            if (horizontalInput == 1)
            {
                ChangePosition(1);
            }
            else if (horizontalInput == -1)
            {
                ChangePosition(-1);
            }
        }
        if (Input.GetButtonDown("Vertical"))
        {
            if (VerticalInput == 1)
            {
                ChangePosition(1);
            }
            else if (VerticalInput == -1)
            {
                ChangePosition(-1);
            }
        }
        if(Input.GetButtonDown("Confirm") || Input.GetButtonDown("Submit"))
            Interact();
    }

    private void Interact()
    {
                audioSource.clip = interactSound;
                audioSource.Play();
                
                options[currentPosition].GetComponent<Button>().onClick.Invoke();
            
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

        
        switch(currentPosition){
            case 0:
                rect.position = new Vector3(options[currentPosition].position.x + 200, options[currentPosition].position.y, 0);
            break;
            case 1:
                rect.position = new Vector3(options[currentPosition].position.x, options[currentPosition].position.y -200, 0);
            break;
            case 2:
                rect.position = new Vector3(options[currentPosition].position.x-200, options[currentPosition].position.y, 0);
            break;
            case 3:
                rect.position = new Vector3(options[currentPosition].position.x, options[currentPosition].position.y+200, 0);
            break;
        }
    }
    }
