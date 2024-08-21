using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;


public class PlayerComponent : MonoBehaviour
{
    public int PlayID;
    [SerializeField] private Tank m_Tank;
    [SerializeField] private Canvas m_Canvas;
    [SerializeField] private GameObject ReticlePrefab;
    [SerializeField] private PlayerInput m_PlayerInput;
    [SerializeField] private MeshRenderer m_MeshRenderer_Tank;
    [SerializeField] private MeshRenderer m_MeshRenderer_Gun;
    [SerializeField] private MeshRenderer m_MeshRenderer_Top;
    [SerializeField] private GameObject ShatterModel;
    [SerializeField] private bool CrashTheGame = false;
    [SerializeField] private GameObject m_Explosion;
    [SerializeField] private AudioSource m_ExplosionSound;
    public TextMeshProUGUI[] stockTexts;
    public GameObject assignedRespawnPoint;
    public dmPlayerDataWrapper pData;

    [SerializeField]public IgamePlayerData playerData;
    // Start is called before the first frame update
    void Start()
    {
        m_Canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        GameObject reticle = Instantiate(ReticlePrefab, m_Canvas.transform);
        m_Tank.SetReticle(reticle);
        if (m_PlayerInput == null)
        {
            m_PlayerInput = GetComponent<PlayerInput>();
        }
        switch(PlayID)
        {
            case 1:
            m_Tank.m_Reticle.GetComponent<ReticleControl>().SetColor(Color.red);
            break;
            case 2:
            m_Tank.m_Reticle.GetComponent<ReticleControl>().SetColor(Color.blue);
            break;
            case 3:
            m_Tank.m_Reticle.GetComponent<ReticleControl>().SetColor(Color.yellow);
            break;
            case 4:
            m_Tank.m_Reticle.GetComponent<ReticleControl>().SetColor(Color.green);
            break;
            default:
            m_Tank.m_Reticle.GetComponent<ReticleControl>().SetColor(Color.white);
            break;
        }
        
        

        if(m_PlayerInput.devices[0].displayName == "Keyboard" || m_PlayerInput.devices[0].displayName == "Mouse")
        {
            m_Tank.m_Reticle.GetComponent<ReticleControl>().usingMouse = true;
        }
        else
        {
            m_Tank.m_Reticle.GetComponent<ReticleControl>().usingMouse = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Player Input Calls
    public void Move(InputAction.CallbackContext context)
    {
        m_Tank.Move(context.ReadValue<Vector2>());
    }

    public void Shoot()
    {
        m_Tank.Shoot();
    }

    public void Reset()
    {
        m_Tank.Reset();
    }

    public void Aim(InputAction.CallbackContext context)
    {
        m_Tank.m_Reticle.GetComponent<ReticleControl>().Move(context.ReadValue<Vector2>());
    }

    public void LoseStock()
    {
        //adjust data in playerData as dmPlayerData
        pData.data.stock--;
        pData.data.deaths++;
        GameObject explode = Instantiate(m_Explosion,  gameObject.transform.position, Quaternion.identity);
        m_ExplosionSound.Play();
       // explode.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

       // Debug.Log("Player " + PlayID + " has " + data.stock + " stock left");
       // Debug.Log("Player " + PlayID + " has " + data.deaths + " deaths");
        
        if(pData.data.stock <= 0)
        {
            GameMode gameMode = GameObject.FindObjectOfType<GameMode>();
            m_MeshRenderer_Tank.enabled = false;
            m_MeshRenderer_Gun.enabled = false;
            m_MeshRenderer_Top.enabled = false;
            gameObject.GetComponent<BoxCollider>().enabled = false;
           m_Tank.m_Reticle.GetComponent<ReticleControl>().enabled = false;
          m_Tank.m_Reticle.GetComponent<Image>().enabled = false;

            gameObject.GetComponent<PlayerComponent>().enabled = false;
            stockTexts[pData.data.deaths-1].gameObject.active = false;
            gameMode.ProcessGameEnd();
        }else{
        stockTexts[pData.data.deaths-1].gameObject.active = false;
        //Shatter crashes the game
        if(CrashTheGame)
        {
        Transform originalPosition = gameObject.transform;
              Instantiate(ShatterModel, originalPosition);
        }
      
        //Instantiate explosion
        gameObject.transform.position = assignedRespawnPoint.transform.position;
        }
      //  gameObject.GetComponent<MeshRenderer>().enabled = false;

      //  gameObject.GetComponent<MeshRenderer>().enabled = true;
    }

    public int GetStock()
    {
        return pData.data.stock;
    }

}
