using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JSONReader : MonoBehaviour
{
    public TextAsset metadataJSON;
    // Start is called before the first frame update

    [SerializeField]
    private Text _title;

    public int x;

    [System.Serializable]
    public class Metadata {
        public int id;
        public string[] steps;
    }

    [System.Serializable]
    public class MetadataList {
        public Metadata[] metadata;
    }

    public void Start()
    {
        MetadataList metadataList = new MetadataList();
        metadataList = JsonUtility.FromJson<MetadataList>(metadataJSON.text);
        print(metadataList.metadata[0].steps[0]);
        _title.text = metadataList.metadata[0].steps[0];

    }

    public void OnButtonClick()
    {
        x = x+1;
        MetadataList metadataList = new MetadataList();
        metadataList = JsonUtility.FromJson<MetadataList>(metadataJSON.text);
      //  print(metadataList.metadata[0].steps[x]);
        _title.text = metadataList.metadata[0].steps[x];
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.D)) {
            transform.position += new Vector3(1,0,0); 
        }
    }
}
