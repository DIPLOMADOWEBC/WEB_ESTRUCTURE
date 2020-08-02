using System;
using System.Text;
using System.Web;
using System.Collections.Generic;

namespace Infiniteskills.Helpers
{
   public class GridElement
   {
      public HtmlString DefaultProperties()
      {
         return DefaultProperties(null);
      }
      public HtmlString DefaultProperties(Dictionary<string,string> overwriteList) 
      {
         Dictionary<string, string> defaultProperties = new Dictionary<string, string>();
         defaultProperties = new Dictionary<string, string>();
         defaultProperties.Add("datatype", "'json'");
         defaultProperties.Add("mtype", "'POST'");
         defaultProperties.Add("loadonce", "true");
         defaultProperties.Add("rowNum", "100");
         defaultProperties.Add("rowList", "[100,300,500]");
         defaultProperties.Add("sortorder", "'asc'");
         defaultProperties.Add("viewrecords", "true");
         defaultProperties.Add("gridview", "true");
         defaultProperties.Add("autoencode", "true");
         defaultProperties.Add("autowidth", "true");
         defaultProperties.Add("pgtext", "null");
         defaultProperties.Add("styleUI ", "'Bootstrap'");
         defaultProperties.Add("responsive", "true");

         if (overwriteList != null) {
            foreach (var item in overwriteList) {
               if (defaultProperties.ContainsKey(item.Key))
                  defaultProperties[item.Key] = item.Value;
            }
         }

         StringBuilder sb = new StringBuilder();
         foreach (var item in defaultProperties)
         {
            if (!string.IsNullOrEmpty(item.Value))
               sb.AppendLine(item.Key + ": " + item.Value + ",");
         }

         return new HtmlString(HttpUtility.HtmlDecode(sb.ToString()));
      }

      public HtmlString CreateEvent(string name, string parameters, string code) {

         StringBuilder sb = new StringBuilder();
         sb.AppendLine(name + ": function (" + parameters + ") {");
         sb.AppendLine("\t" + code);
         sb.AppendLine("},");

         return new HtmlString(HttpUtility.HtmlDecode(sb.ToString()));
      }

    

      public HtmlString RowDeletedStyle(string column, string deletedValue)
      {
         StringBuilder sb = new StringBuilder();
         sb.AppendLine("rowattr: function (rd) {debugger;");
         sb.AppendLine("if (rd." + column + " == '" + deletedValue + "'){");
         sb.AppendLine("return { 'class': 'jqgrid-deletedrow' };");
         sb.AppendLine("}");
         sb.Append("},");

         return new HtmlString(HttpUtility.HtmlDecode(sb.ToString()));
      }

   }
}
