using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class FinishButton : MonoBehaviour
{

    Button finishButton;
    public PreviewHandler headPreview;
    public PreviewHandler bodyPreview;

    string path = "./Assets/Resources/Costumes/";
    // Start is called before the first frame update
    void Start()
    {
        finishButton = GetComponent<Button>();
        finishButton.onClick.AddListener(OnFinish);
    }

    void OnFinish()
    {
        ToPng(headPreview.atlas[0].texture, "head");
        ToPng(bodyPreview.atlas[0].texture, "body");
    }
    void ToPng(Texture2D source,string part)
    {
        Color[] sourceColor = source.GetPixels();

        int width = source.width , height = source.height ;

        Texture2D newT = new Texture2D(width, height, TextureFormat.ARGB32, false);
        int length = width * height;
        Color[] newColor = new Color[length];

        int i = 0;
        for (int y = 0; y < height; y++)
        {
            int sourceIndex = y * source.width;
            for (int x = 0; x < width; x++)
            {
                newColor[i++] = sourceColor[sourceIndex++];
            }
        }
        newT.SetPixels(newColor);
        newT.Apply();
        byte[] bytes = newT.EncodeToPNG();
        File.WriteAllBytes(path + part + "/" + source.name + "_new.png", bytes);

    }


}
