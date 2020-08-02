namespace Infiniteskills.Helpers
{
   public class JsonResultMessage
   {
      public bool success { get; set; }
      public string message { get; set; }
      public string url { get; set; }
      public object data { get; set; }
      public JsonResultMessage()
      {
         this.success = true;
      }
   }
}
