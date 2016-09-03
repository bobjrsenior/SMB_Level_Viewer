using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour {

    [SerializeField]
    private Text errorText;

    [SerializeField]
    private Material blueMaterial;

    [SerializeField]
    private Material greenMaterial;

    [SerializeField]
    private Material redMaterial;

    [SerializeField]
    private GameObject startPrefab;

    [SerializeField]
    private GameObject goalPrefab;

    [SerializeField]
    private GameObject bumperPrefab;

    [SerializeField]
    private GameObject jamaBarPrefab;

    [SerializeField]
    private GameObject bananaSinglePrefab;

    [SerializeField]
    private GameObject bananaBunchPrefab;


    private ConfigObject[] startObjects = new ConfigObject[1];
    private ConfigObject[] goalObjects = new ConfigObject[50];
    private ConfigObject[] bumperObjects = new ConfigObject[50];
    private ConfigObject[] jambaBarObjects = new ConfigObject[50];
    private ConfigObject[] bananaObjects = new ConfigObject[50];
    private ConfigObject falloutObject = new ConfigObject();



    // Use this for initialization
    void Start()
    {

        try {
            importModel();
        }
        catch(System.Exception e)
        {
            errorText.text = "Error Loading .obj file: " + Filenames.objectFilename;
            return;
        }

        try {
            if (importConfig() != 0)
            {
                errorText.text = "Error Loading config file: " + Filenames.configFilename;
            }
        }
        catch (System.Exception e)
        {
            errorText.text = "Error Loading config file:  " + Filenames.configFilename;
            print(e);
            return;
        }


    }

    private void importModel()
    {
        Mesh holderMesh = new Mesh();
        ObjImporter newMesh = new ObjImporter();
        holderMesh = newMesh.ImportFile(Filenames.objectFilename);

        //MeshRenderer renderer = gameObject.AddComponent<MeshRenderer>();
        MeshFilter filter = gameObject.AddComponent<MeshFilter>();
        filter.mesh = holderMesh;
        gameObject.AddComponent<MeshCollider>();

    }

    private int importConfig()
    {
        Scanner k;
        try
        {

            k = new Scanner(System.IO.File.ReadAllText(Filenames.configFilename));

        }
        catch (System.IO.FileNotFoundException e)
        {
            print("File not found");
            return 1;
        }

        startObjects[0] = new ConfigObject();

        string line;
        do
        {
            line = k.nextLine();
            int index;
            string[] lineSplit = line.Split(' ');
            if (lineSplit.Length != 10) { continue; }
            switch (lineSplit[0])
            {
                case "start":
                    index = IntParseFast(lineSplit[2]);
                    if (index < startObjects.Length)
                    {
                        if(startObjects[index] == null)
                        {
                            startObjects[index] = new ConfigObject();
                        }
                        if (lineSplit[5].Equals("pos"))
                        {
                            switch (lineSplit[7])
                            {
                                case "x":
                                    startObjects[index].position.x = float.Parse(lineSplit[9]);
                                    break;
                                case "y":
                                    startObjects[index].position.y = float.Parse(lineSplit[9]);
                                    break;
                                case "z":
                                    startObjects[index].position.z = float.Parse(lineSplit[9]);
                                    break;
                            }
                        }
                        else if (lineSplit[5].Equals("rot"))
                        {
                            switch (lineSplit[7])
                            {
                                case "x":
                                    startObjects[index].rotation.x = float.Parse(lineSplit[9]);
                                    break;
                                case "y":
                                    startObjects[index].rotation.y = float.Parse(lineSplit[9]);
                                    break;
                                case "z":
                                    startObjects[index].rotation.z = float.Parse(lineSplit[9]);
                                    break;
                            }
                        }
                    }


                    break;
                case "goal":
                    index = IntParseFast(lineSplit[2]);
                    if (index < goalObjects.Length)
                    {
                        if (goalObjects[index] == null)
                        {
                            goalObjects[index] = new ConfigObject();
                        }
                        if (lineSplit[5].Equals("pos"))
                        {
                            switch (lineSplit[7])
                            {
                                case "x":
                                    goalObjects[index].position.x = float.Parse(lineSplit[9]);
                                    break;
                                case "y":
                                    goalObjects[index].position.y = float.Parse(lineSplit[9]);
                                    break;
                                case "z":
                                    goalObjects[index].position.z = float.Parse(lineSplit[9]);
                                    break;
                            }
                        }
                        else if (lineSplit[5].Equals("rot"))
                        {
                            switch (lineSplit[7])
                            {
                                case "x":
                                    goalObjects[index].rotation.x = float.Parse(lineSplit[9]);
                                    break;
                                case "y":
                                    goalObjects[index].rotation.y = float.Parse(lineSplit[9]);
                                    break;
                                case "z":
                                    goalObjects[index].rotation.z = float.Parse(lineSplit[9]);
                                    break;
                            }
                        }
                        else if (lineSplit[5].Equals("type"))
                        {
                            goalObjects[index].type = lineSplit[9];
                        }
                    }
                    break;
                case "bumper":
                    index = IntParseFast(lineSplit[2]);
                    if (index < bumperObjects.Length)
                    {
                        if (bumperObjects[index] == null)
                        {
                            bumperObjects[index] = new ConfigObject();
                        }
                        if (lineSplit[5].Equals("pos"))
                        {
                            switch (lineSplit[7])
                            {
                                case "x":
                                    bumperObjects[index].position.x = float.Parse(lineSplit[9]);
                                    break;
                                case "y":
                                    bumperObjects[index].position.y = float.Parse(lineSplit[9]);
                                    break;
                                case "z":
                                    bumperObjects[index].position.z = float.Parse(lineSplit[9]);
                                    break;
                            }
                        }
                        else if (lineSplit[5].Equals("rot"))
                        {
                            switch (lineSplit[7])
                            {
                                case "x":
                                    bumperObjects[index].rotation.x = float.Parse(lineSplit[9]);
                                    break;
                                case "y":
                                    bumperObjects[index].rotation.y = float.Parse(lineSplit[9]);
                                    break;
                                case "z":
                                    bumperObjects[index].rotation.z = float.Parse(lineSplit[9]);
                                    break;
                            }
                        }
                        else if (lineSplit[5].Equals("scl"))
                        {
                            switch (lineSplit[7])
                            {
                                case "x":
                                    bumperObjects[index].scale.x = float.Parse(lineSplit[9]);
                                    break;
                                case "y":
                                    bumperObjects[index].scale.y = float.Parse(lineSplit[9]);
                                    break;
                                case "z":
                                    bumperObjects[index].scale.z = float.Parse(lineSplit[9]);
                                    break;
                            }
                        }
                    }
                    break;
                case "jamabar":
                    index = IntParseFast(lineSplit[2]);
                    if (index < jambaBarObjects.Length)
                    {
                        if (jambaBarObjects[index] == null)
                        {
                            jambaBarObjects[index] = new ConfigObject();
                        }
                        if (lineSplit[5].Equals("pos"))
                        {
                            switch (lineSplit[7])
                            {
                                case "x":
                                    jambaBarObjects[index].position.x = float.Parse(lineSplit[9]);
                                    break;
                                case "y":
                                    jambaBarObjects[index].position.y = float.Parse(lineSplit[9]);
                                    break;
                                case "z":
                                    jambaBarObjects[index].position.z = float.Parse(lineSplit[9]);
                                    break;
                            }
                        }
                        else if (lineSplit[5].Equals("rot"))
                        {
                            switch (lineSplit[7])
                            {
                                case "x":
                                    jambaBarObjects[index].rotation.x = float.Parse(lineSplit[9]);
                                    break;
                                case "y":
                                    jambaBarObjects[index].rotation.y = float.Parse(lineSplit[9]);
                                    break;
                                case "z":
                                    jambaBarObjects[index].rotation.z = float.Parse(lineSplit[9]);
                                    break;
                            }
                        }
                        else if (lineSplit[5].Equals("scl"))
                        {
                            switch (lineSplit[7])
                            {
                                case "x":
                                    jambaBarObjects[index].scale.x = float.Parse(lineSplit[9]);
                                    break;
                                case "y":
                                    jambaBarObjects[index].scale.y = float.Parse(lineSplit[9]);
                                    break;
                                case "z":
                                    jambaBarObjects[index].scale.z = float.Parse(lineSplit[9]);
                                    break;
                            }
                        }
                    }
                    break;

                case "banana":
                    index = IntParseFast(lineSplit[2]);
                    if (index < bananaObjects.Length)
                    {
                        if (bananaObjects[index] == null)
                        {
                            bananaObjects[index] = new ConfigObject();
                        }
                        if (lineSplit[5].Equals("pos"))
                        {
                            switch (lineSplit[7])
                            {
                                case "x":
                                    bananaObjects[index].position.x = float.Parse(lineSplit[9]);
                                    break;
                                case "y":
                                    bananaObjects[index].position.y = float.Parse(lineSplit[9]);
                                    break;
                                case "z":
                                    bananaObjects[index].position.z = float.Parse(lineSplit[9]);
                                    break;
                            }
                        }
                        else if (lineSplit[5].Equals("type"))
                        {
                            bananaObjects[index].type = lineSplit[9];
                        }
                    }
                    break;

                case "fallout":
                    index = IntParseFast(lineSplit[2]);
                    if (index == 0)
                    {
                        if(lineSplit[5].Equals("pos") && lineSplit[7].Equals("y"))
                        {
                            falloutObject.position.y = float.Parse(lineSplit[9]);
                        }
                    }
                        break;
                case "background":
                    //Not Implemented
                    break;

                default:
                    //Unknown type
                    break;

            }
        }while (k.hasNext());

        GameObject monkey = null;

        //Spawn Start Position (should only be 1)
        foreach (ConfigObject obj in startObjects)
        {
            if (obj != null)
            {
                GameObject newObject = (Instantiate(startPrefab, obj.position, Quaternion.Euler(obj.rotation)) as GameObject);
                newObject.transform.localScale = obj.scale;
                monkey = newObject;
            }
        }

        //Spawn Goal Positions
        foreach (ConfigObject obj in goalObjects)
        {
            if (obj != null)
            {
                GameObject newObject = (Instantiate(goalPrefab, obj.position, Quaternion.Euler(obj.rotation)) as GameObject);
                newObject.transform.localScale = obj.scale;
                switch (obj.type)
                {
                    case "B":
                        newObject.GetComponent<MeshRenderer>().material = blueMaterial;
                        break;
                    case "G":
                        newObject.GetComponent<MeshRenderer>().material = greenMaterial;
                        break;
                    case "R":
                        newObject.GetComponent<MeshRenderer>().material = redMaterial;
                        break;
                }
            }
        }

        //Spawn Bumper Positions
        foreach (ConfigObject obj in bumperObjects)
        {
            if (obj != null)
            {
                GameObject newObject = (Instantiate(bumperPrefab, obj.position, Quaternion.Euler(obj.rotation)) as GameObject);
                newObject.transform.localScale = obj.scale;
            }
        }

        //Spawn JambaBar Positions
        foreach (ConfigObject obj in jambaBarObjects)
        {
            if (obj != null)
            {
                GameObject newObject = (Instantiate(jamaBarPrefab, obj.position, Quaternion.Euler(obj.rotation)) as GameObject);
                newObject.transform.localScale = obj.scale;
            }
        }

        //Spawn Banana Positions
        foreach (ConfigObject obj in bananaObjects)
        {
            if (obj != null)
            {
                GameObject newObject = null;
                if (obj.type.Equals("N"))
                {
                    newObject = (Instantiate(bananaSinglePrefab, obj.position, Quaternion.Euler(obj.rotation)) as GameObject);
                }
                else
                {
                    newObject = (Instantiate(bananaBunchPrefab, obj.position, Quaternion.Euler(obj.rotation)) as GameObject);
                }
                newObject.transform.localScale = obj.scale;
            }
        }

        //Set Fallout Plane
        monkey.GetComponent<MonkeyMovement>().setFalloutPlane(falloutObject.position.y);
        return 0;
    }

    private int IntParseFast(string value)
    {
        int result = 0;
        for (int e = 0; e < value.Length; ++e)
        {
            char letter = value[e];
            result = 10 * result + (letter - '0');
        }
        return result;
    }
}

class ConfigObject
{
    public Vector3 position;

    public Vector3 rotation;

    public Vector3 scale;

    public string type;

    public ConfigObject()
    {
        position = Vector3.zero;
        rotation = Vector3.zero;
        scale = Vector3.one;

        type = "B";
    }

    
    public override string ToString()
    {
        return position.ToString() + " : " + rotation.ToString() + " : " + scale.ToString() + " : " + type;
    }

}

class Scanner : System.IO.StringReader
{
    char[] separators = {'\n'};

    string[] wordList;
    int curWord;

    public Scanner(string source) : base(source)
    {

        wordList = source.Split(separators);
        curWord = 0;
    }

    public string nextLine()
    {

        ++curWord;
        if (curWord > wordList.Length)
        {
            return "";
        }
        else
        {
            wordList[curWord - 1] = wordList[curWord - 1].Trim();
            return wordList[curWord - 1];
        }

    }

    public bool hasNext()
    {
        return (curWord < wordList.Length);
    }
}
