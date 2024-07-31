using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SerializationUtils
{
   


   public static string MakeUniqueFileName(string fileName)
   {
       return fileName + System.DateTime.Now.ToString("yyyyMMddHHmmssfff");
   }
}
