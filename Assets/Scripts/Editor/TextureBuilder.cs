using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    public static class TextureBuilder
    {
        [MenuItem("Custom/Create Textures")]
        private static void CreateTextures()
        {
            const int count = 32;
            const int width = 512;
            const int height = 32;
            for (int i = 0; i < count; ++i)
            {
                var color = Color.Lerp(Color.black, Color.white,  (float)i * 1.0f / (float)count);
                var colors = Enumerable.Range(0, width * height).Select(x => color).ToArray();
            
                var texture = new Texture2D(width, height, TextureFormat.RGB24, false);
                texture.SetPixels(colors);
                texture.Apply();
            
                var path = Application.dataPath + $"/{i:D3}.png";
                System.IO.File.WriteAllBytes(path, texture.EncodeToPNG());

                Object.DestroyImmediate(texture);
            }
        
            AssetDatabase.Refresh();
        }
    }
}
