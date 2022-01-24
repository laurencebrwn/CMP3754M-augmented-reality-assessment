using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.Interaction.Toolkit.AR;

public class CounterScript : MonoBehaviour
{
  [SerializeField]
  private GameObject CountObj;
  [SerializeField]
  private Text CountText;
  [SerializeField]
  private Button CountButton;
  [SerializeField]
  private string TagToCount;

  private int objCount;

  // Start is called before the first frame update
  void Awake()
  {
      CountObj.SetActive(false);
      objCount = 0;
      CountButton.onClick.AddListener(() => DeleteObjs());
  }

  // Update is called once per frame
  void Update()
  {
    objCount = GameObject.FindGameObjectsWithTag(TagToCount).Length;
    if (objCount != 0)
    {
      CountObj.SetActive(true);
      CountText.text = objCount.ToString();
    }
    else
    {
      CountObj.SetActive(false);
    }
  }

  void DeleteObjs()
  {
    GameObject[] objs = GameObject.FindGameObjectsWithTag(TagToCount);
    for(int i=0; i< objs.Length; i++)
    {
      GameObject.Destroy(objs[i]);
    }
  }
}
