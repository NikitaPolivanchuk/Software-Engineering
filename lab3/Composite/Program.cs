namespace Composite;

internal abstract class Program
{
   public static void Main(string[] args)
   {
      var root = new LightNodeElement("div", true, false);
      var child = new LightNodeElement("span", true, false);
      var text = new LightTextNode("Click me!");

      child.AddChild(text);
      root.AddChild(child);

      root.AddEventListener("click", sender =>
      {
         Console.WriteLine($"[Root {sender.TagName}] caught click event");
      });

      child.AddEventListener("click", sender =>
      {
         Console.WriteLine($"[Child {sender.TagName}] caught click event");
      });

      Console.WriteLine("Dispatching click on text node’s parent (child):");
      child.DispatchEvent("click");
   }
}