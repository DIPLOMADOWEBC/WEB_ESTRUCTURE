namespace Infiniteskills.Helpers
{
   public enum MenuBarType {
      Custom = 0,
      Small = 1
   }
   public enum MenuBarButtonType
   { 
      Custom =0,
      New = 1,
      Edit = 2,
      Copy = 3,
      Delete = 4,
      Save = 6,
      Exit = 7,
      Cancel = 8,
      Preview = 9,
      ExportXls = 10,
      SaveExit = 11,
      Asignar = 12,
      Aprobar = 13,
      Desaprobar = 14,
      Aperturar = 15,
      Cerrar = 16,
      Print = 17
   }
   public class ItemMenuBar
   {

      private MenuBarButtonType _menuBarButtonType = MenuBarButtonType.Custom;
      public string Name { get; set; }
      public string Argument { get; set; }
      public string ImgPath { get; set; }
      public string Value { get; set; }
      public bool Disabled { get; set; }
      public MenuBarButtonType MenuBarButtonType {
         get { return _menuBarButtonType; } 
      }

      public ItemMenuBar(MenuBarButtonType menuBarButtonType)
      {
         _menuBarButtonType = menuBarButtonType;
      }

      public ItemMenuBar(MenuBarButtonType menuBarButtonType, bool disabled)
      {
         _menuBarButtonType = menuBarButtonType;
         this.Disabled = disabled;
      }

      public ItemMenuBar(string name, MenuBarButtonType menuBarButtonType)
      {
         _menuBarButtonType = menuBarButtonType;
         this.Name = name;
      }

      public ItemMenuBar(string name, string value, string argument)
      {
         this.Name = name;
         this.ImgPath = "";
         this.Argument = argument;
         this.Value = value;
      }
      public ItemMenuBar(string name, string value, string argument, string img, bool disabled)
      {
         this.Name = name;
         this.Argument = argument;
         this.ImgPath = img;
         this.Value = value;
         this.Disabled = disabled;
      }
   }
}
