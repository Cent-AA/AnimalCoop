using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManage : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject playerPrefab2;
    [SerializeField] private Transform[] spawnPoints;
    private bool wasdjoined=false;
    private bool arrowsjoined=false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Keyboard.current ==null) return;
        if(!wasdjoined && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            var player =PlayerInput.Instantiate(playerPrefab,controlScheme: "Goat",
            pairWithDevice: Keyboard.current);

            if (spawnPoints.Length > 0)
            {
                player.transform.position =spawnPoints[0].position;
            }

            wasdjoined=true;
        }
        if(!arrowsjoined && Keyboard.current.backspaceKey.wasPressedThisFrame)
        {
            var player =PlayerInput.Instantiate(playerPrefab2,controlScheme: "Chicken",
            pairWithDevice: Keyboard.current);

            if (spawnPoints.Length > 1)
            {
                player.transform.position =spawnPoints[1].position;
            }
            arrowsjoined =true;
        }
    }
}
