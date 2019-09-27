using System;
using System.IO;
using Microsoft.Extensions.Logging;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.Primitives;
 
public static void Run(Stream myBlob, Stream outputBlob, ILogger log)
{
    try
    {
         using (var image = Image.Load(myBlob))
        {
            image.Mutate(x => x.Resize(new ResizeOptions { 
                Size = new Size { 
                    Height = 100, 
                    Width = 100 }, 
                Mode = ResizeMode.Crop 
            }));
 
            using (var ms = new MemoryStream())
            {
                image.SaveAsPng(outputBlob);
            }
        }
 
        log.LogInformation("Done", null);
    }
    catch (Exception ex)
    {
        log.LogInformation(ex.Message, null);
    }
}
