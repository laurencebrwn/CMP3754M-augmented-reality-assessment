using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.Interaction.Toolkit.AR;

[RequireComponent(typeof(ARRaycastManager))]


public class UIController : MonoBehaviour
{
  [SerializeField]
  private Button CatBtn;

  [SerializeField]
  private Button ChickenBtn;

  [SerializeField]
  private Button DogBtn;

  [SerializeField]
  private Button LionBtn;

  [SerializeField]
  private Button PenguinBtn;

  private GameObject currentPlacementInteractable;
  private ARRaycastManager arRaycastManager;
  private static List<ARRaycastHit> hits = new List<ARRaycastHit>();

  public GameObject catPlacementInteractable;
  public GameObject chickenPlacementInteractable;
  public GameObject dogPlacementInteractable;
  public GameObject lionPlacementInteractable;
  public GameObject penguinPlacementInteractable;


  void Awake()
  {
    catPlacementInteractable = GameObject.FindWithTag("catInteractable");
    chickenPlacementInteractable = GameObject.FindWithTag("chickenInteractable");
    dogPlacementInteractable = GameObject.FindWithTag("dogInteractable");
    lionPlacementInteractable = GameObject.FindWithTag("lionInteractable");
    penguinPlacementInteractable = GameObject.FindWithTag("penguinInteractable");
    arRaycastManager = GetComponent<ARRaycastManager>();
    CatBtn.onClick.AddListener(() => ChangePrefabTo("Cat"));
    ChickenBtn.onClick.AddListener(() => ChangePrefabTo("Chicken"));
    DogBtn.onClick.AddListener(() => ChangePrefabTo("Dog"));
    LionBtn.onClick.AddListener(() => ChangePrefabTo("Lion"));
    PenguinBtn.onClick.AddListener(() => ChangePrefabTo("Penguin"));

    ChangePrefabTo("Cat");
  }

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    if(currentPlacementInteractable == null)
    {
      return;
    }
    if (Input.touchCount > 0)
    {
      Touch touch = Input.GetTouch(0);
      if (touch.phase == TouchPhase.Began)
      {
        var touchPosition = touch.position;
        bool isOverUI = EventSystem.current.IsPointerOverGameObject(touch.fingerId);
        if (isOverUI)
        {
          //currentPlacementInteractable.SetActive(false);
          Debug.Log(" blocked raycast");
          return;
        }
        else
        {
          Debug.Log("ar raycast");
          //currentPlacementInteractable.SetActive(true);
        }
      }
    }
  }

  void ChangePrefabTo(string prefabName)
  {
    //create temp color var to access alpha.
    Color cc = CatBtn.image.color;
    Color chc = ChickenBtn.image.color;
    Color dc = DogBtn.image.color;
    Color lc = LionBtn.image.color;
    Color pc = PenguinBtn.image.color;

    Debug.Log("is cat" + cc.a + " " + chc.a + " " + dc.a + " " + lc.a + " " + pc.a);
    switch (prefabName)
    {
      case "Cat":
        Debug.Log("is cat");
        //Logger.Instance.LogInfo( ("is wayne");
        cc.a = 1f;
        chc.a = 0.5f;
        dc.a = 0.5f;
        lc.a = 0.5f;
        pc.a = 0.5f;
        catPlacementInteractable.SetActive(false);
        chickenPlacementInteractable.SetActive(false);
        dogPlacementInteractable.SetActive(false);
        lionPlacementInteractable.SetActive(false);
        penguinPlacementInteractable.SetActive(false);
        currentPlacementInteractable = catPlacementInteractable;
        currentPlacementInteractable.SetActive(true);
        break;
      case "Chicken":
        Debug.Log("is chicken");
        //Logger.Instance.LogInfo( ("is Patrick");
        cc.a = 0.5f;
        chc.a = 1f;
        dc.a = 0.5f;
        lc.a = 0.5f;
        pc.a = 0.5f;
        catPlacementInteractable.SetActive(false);
        chickenPlacementInteractable.SetActive(false);
        dogPlacementInteractable.SetActive(false);
        lionPlacementInteractable.SetActive(false);
        penguinPlacementInteractable.SetActive(false);
        currentPlacementInteractable = chickenPlacementInteractable;
        currentPlacementInteractable.SetActive(true);
        break;
      case "Dog":
        Debug.Log("is dog");
        //Logger.Instance.LogInfo( ("is Patrick");
        cc.a = 0.5f;
        chc.a = 0.5f;
        dc.a = 1f;
        lc.a = 0.5f;
        pc.a = 0.5f;
        catPlacementInteractable.SetActive(false);
        chickenPlacementInteractable.SetActive(false);
        dogPlacementInteractable.SetActive(false);
        lionPlacementInteractable.SetActive(false);
        penguinPlacementInteractable.SetActive(false);
        currentPlacementInteractable = dogPlacementInteractable;
        currentPlacementInteractable.SetActive(true);
        break;
      case "Lion":
        Debug.Log("is lion");
        //Logger.Instance.LogInfo( ("is Patrick");
        cc.a = 0.5f;
        chc.a = 0.5f;
        dc.a = 0.5f;
        lc.a = 1f;
        pc.a = 0.5f;
        catPlacementInteractable.SetActive(false);
        chickenPlacementInteractable.SetActive(false);
        dogPlacementInteractable.SetActive(false);
        lionPlacementInteractable.SetActive(false);
        penguinPlacementInteractable.SetActive(false);
        currentPlacementInteractable = lionPlacementInteractable;
        currentPlacementInteractable.SetActive(true);
        break;
      case "Penguin":
        Debug.Log("is penguin");
        //Logger.Instance.LogInfo( ("is Patrick");
        cc.a = 0.5f;
        chc.a = 0.5f;
        dc.a = 0.5f;
        lc.a = 0.5f;
        pc.a = 1f;
        catPlacementInteractable.SetActive(false);
        chickenPlacementInteractable.SetActive(false);
        dogPlacementInteractable.SetActive(false);
        lionPlacementInteractable.SetActive(false);
        penguinPlacementInteractable.SetActive(false);
        currentPlacementInteractable = penguinPlacementInteractable;
        currentPlacementInteractable.SetActive(true);
        break;
    }
    CatBtn.image.color = cc;
    ChickenBtn.image.color = chc;
    DogBtn.image.color = dc;
    LionBtn.image.color = lc;
    PenguinBtn.image.color = pc;
  }
}
