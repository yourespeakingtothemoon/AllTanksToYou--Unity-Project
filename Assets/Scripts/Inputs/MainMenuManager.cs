using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;
using UnityEngine.SceneManagement;


public enum MenuState
{
    PressStart,
    MainMenu,
    SinglePlayerMenu,
    MultiPlayerMenu,
    OptionsMenu,
    ExtrasMenu
}
public enum FadeState
{
    FadeIn,
    FadeOut,
    None
}

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] MenuState currentState;
    [SerializeField] CanvasGroup pressStartCanvas;
    [SerializeField] CanvasGroup mainMenuCanvas;
    [SerializeField] CanvasGroup spMenuCanvas;
    [SerializeField] CanvasGroup mpMenuCanvas;
    [SerializeField] CanvasGroup optionsMenuCanvas;
    [SerializeField] CanvasGroup extrasMenuCanvas;

    [SerializeField] Camera mainCamera;
    [SerializeField] Camera spCamera;
    [SerializeField] Cinemachine.CinemachineDollyCart spCart;
    [SerializeField] Camera mpCamera;
    [SerializeField] Cinemachine.CinemachineDollyCart mpCart;
    [SerializeField] float TrackSpeed = 4;


    [SerializeField] GameObject[] ControllerAssets;
    [SerializeField] Material[] ControllerOffMaterials;
    [SerializeField] Material[] ControllerOnMaterials;

    private CanvasGroup currentCanvas;
    private Camera currentCamera;
    private FadeState fadeState;
    private int numOfPlayers = 0;

    [SerializeField] private PlayerInputManager playerInputManager;
    [SerializeField] private TankToYou playerInputActions;

    

    // Start is called before the first frame update
    void Start()
    {
        currentCanvas = mainMenuCanvas;
        currentState = MenuState.MainMenu;
        currentCamera = mainCamera;
    }

    void Awake()
    {
        playerInputActions = new TankToYou();
        playerInputActions.Menus.Enable();
       // playerInputActions.Menus.PressStart.performed += ctx => PressStart();
        playerInputActions.Menus.Back.performed += ctx => Back();
    }

    // Update is called once per frame
    void Update()
    {
        switch (fadeState)
        {
            case FadeState.FadeIn:
                Invoke ("FadeIn", 5f);
                break;
            case FadeState.FadeOut:
                FadeOut();
                break;
        }
    }

    private void FadeOut()
    {
        currentCanvas.alpha -= Time.deltaTime *10;
    }
    private void FadeIn()
    {
        currentCanvas.alpha += Time.deltaTime*10;
    }
    public void Transition(CanvasGroup nextCanvas, Camera nextCamera, MenuState nextMenu)
    {
        fadeState = FadeState.FadeOut;
       StartCoroutine(ToNext(nextCanvas, nextCamera, nextMenu));
    }

    private IEnumerator ToNext(CanvasGroup nextCanvas, Camera nextCamera, MenuState nextMenu)
    {
        yield return new WaitForSeconds(.5f);
        currentCanvas.gameObject.SetActive(false);
        TransitionCamera(nextCamera, nextMenu);
        currentCanvas = nextCanvas;
        currentCamera = nextCamera;
        currentState = nextMenu;
        currentCanvas.alpha = 0;
        nextCanvas.gameObject.SetActive(true);
        fadeState = FadeState.FadeIn;
    }

    private void TransitionCamera(Camera nextCamera, MenuState nextMenu)
    {
        nextCamera.gameObject.SetActive(true);
        currentCamera.gameObject.SetActive(false);
        currentCamera = nextCamera;
        if(nextMenu == MenuState.SinglePlayerMenu)
        {
            spCart.m_Speed = TrackSpeed;
            mpCart.m_Speed = -TrackSpeed;
        }
        else if(nextMenu == MenuState.MultiPlayerMenu)
        {
            spCart.m_Speed = -TrackSpeed;
            mpCart.m_Speed = TrackSpeed;
        }
        else
        {
            switch (currentState)
            {
                case MenuState.SinglePlayerMenu:
                    spCart.m_Speed = -TrackSpeed;
                    break;
                case MenuState.MultiPlayerMenu:
                    mpCart.m_Speed = -TrackSpeed;
                    break;
            }
        }
       
    }
    

    public void PressStart()
    {
        if (currentState == MenuState.PressStart){
            Transition(mainMenuCanvas, mainCamera, MenuState.MainMenu);
        }
    }
    public void Back()
    {
        switch(currentState)
        {
            case MenuState.MainMenu:
                Transition(pressStartCanvas, mainCamera, MenuState.PressStart);
                break;
            case MenuState.SinglePlayerMenu:
                Transition(mainMenuCanvas, mainCamera, MenuState.MainMenu);
                break;
            case MenuState.MultiPlayerMenu:
                Transition(mainMenuCanvas, mainCamera, MenuState.MainMenu);
                break;
            case MenuState.OptionsMenu:
                Transition(mainMenuCanvas, mainCamera, MenuState.MainMenu);
                break;
            case MenuState.ExtrasMenu:
                Transition(mainMenuCanvas, mainCamera, MenuState.MainMenu);
                break;
        }
    }

    public void SinglePlayer()
    {
        Transition(spMenuCanvas, spCamera, MenuState.SinglePlayerMenu);
    }
    public void MultiPlayer()
    {
        Transition(mpMenuCanvas, mpCamera, MenuState.MultiPlayerMenu);
    }
    public void Options()
    {
        Transition(optionsMenuCanvas, mainCamera, MenuState.OptionsMenu);
    }
    public void Extras()
    {
        Transition(extrasMenuCanvas, mainCamera, MenuState.ExtrasMenu);
    }
    public void Exit()
    {
        Application.Quit();
    }


    //player input manager player joined and left event

    /*public void ControllerActive()
    {
        Debug.Log("Controller Active");
        ControllerAssets[numOfPlayers].GetComponent<MeshRenderer>().materials[0] = ControllerOnMaterials[numOfPlayers];
        numOfPlayers++;
    }
   

    public void ControllerInactive()
    {
        ControllerAssets[numOfPlayers].GetComponent<MeshRenderer>().materials[0] = ControllerOffMaterials[numOfPlayers];
        numOfPlayers--;
    }*/

    public void OnPlayerJoined()
    {
        Debug.Log("Controller Active");
        ControllerAssets[numOfPlayers].GetComponent<MeshRenderer>().material = ControllerOnMaterials[numOfPlayers];
        numOfPlayers++;
    }

    public void OnPlayerLeft()
    {
       // ControllerAssets[numOfPlayers].GetComponent<MeshRenderer>().materials[0] = ControllerOffMaterials[numOfPlayers];
       // numOfPlayers--;
    }

    public void OnRumbleTestMode()
    {
        MPData.NumberOfPlayers = numOfPlayers;
        SceneManager.LoadScene("RumbleTest", LoadSceneMode.Single);
    }
   
}
