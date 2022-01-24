using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class FinishButton : MonoBehaviour
{

    Button finishButton;
    public PreviewHandler headPreview;
    public PreviewHandler bodyPreview;
    public PreviewHandler basePreview;

    string path = "./Assets/Resources/Costumes/costume_new.png";
    // Start is called before the first frame update
    void Start()
    {
        finishButton = GetComponent<Button>();
        finishButton.onClick.AddListener(OnFinish);
    }

    void OnFinish()
    {
        Texture2D[] textures = { basePreview.atlas[0].texture, headPreview.atlas[0].texture, bodyPreview.atlas[0].texture };
        ToPng(textures);
    }
    void ToPng(Texture2D[] textures)
    {
        
        Color[] sourceColor ;

        int width = textures[0].width , height = textures[0].height ;

        Texture2D newT = new Texture2D(width, height, TextureFormat.ARGB32, false);
        int length = width * height;
        Color[] newColor = new Color[length];
        
        int newIndex, sourceIndex;

        for (int i =0; i<textures.Length;i++)
        {
            sourceColor = textures[i].GetPixels();
            newIndex = 0;
            for (int y = 0; y < height; y++)
            {
                sourceIndex = y * width;
                for (int x = 0; x < width; x++)
                {
                    if (sourceColor[sourceIndex].a != 0)
                    {
                        newColor[newIndex++] = sourceColor[sourceIndex++];
                    }
                    else
                    {
                        newIndex++;
                        sourceIndex++;
                    }
                }
            }
        }
        newT.SetPixels(newColor);
        newT.Apply();
        byte[] bytes = newT.EncodeToPNG();
        File.WriteAllBytes(path, bytes);

    }


}
