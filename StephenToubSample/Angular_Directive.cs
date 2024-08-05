//using System;

//using System;
//using System.Collections.Generic;

//public class Component
//{
//    public string Selector { get; set; }
//    public string HtmlTemplate { get; set; }
//    public string Title { get; set; }
//    private readonly List<Directive> directives;

//    public Component(string selector, string htmlTemplate, string title)
//    {
//        Selector = selector;
//        HtmlTemplate = htmlTemplate;
//        Title = title;
//        directives = new List<Directive>();
//    }

//    public void AddDirective(Directive directive)
//    {
//        directives.Add(directive);
//    }

//    public void OnMouseEnter()
//    {
//        foreach (var directive in directives)
//        {
//            directive.OnMouseEnter();
//        }
//    }

//    public void OnMouseLeave()
//    {
//        foreach (var directive in directives)
//        {
//            directive.OnMouseLeave();
//        }
//    }

//    public void ChangeTitle(string newTitle)
//    {
//        Title = newTitle;
//        Render();
//    }

//    public void Render()
//    {
//        string renderedTemplate = HtmlTemplate.Replace("{{ title }}", Title);

//        foreach (var directive in directives)
//        {
//            renderedTemplate = directive.ModifyStructure(renderedTemplate);
//        }

//        Console.WriteLine(renderedTemplate);
//    }
//}
//public abstract class Directive
//{
//    public abstract void OnMouseEnter();
//    public abstract void OnMouseLeave();
//    protected abstract void Highlight(string color);
//    public abstract string ModifyStructure(string template);
//}
//public class HighlightDirective : Directive
//{
//    public HighlightDirective()
//    {
//    }

//    public override void OnMouseEnter()
//    {
//        Highlight("yellow");
//    }

//    public override void OnMouseLeave()
//    {
//        Highlight(null);
//    }

//    protected override void Highlight(string color)
//    {
//        if (color == null)
//        {
//            Console.WriteLine("Background color cleared.");
//        }
//        else
//        {
//            Console.WriteLine($"Background color set to {color}.");
//        }
//    }
//    public override string ModifyStructure(string template)
//    {
//        // HighlightDirective doesn't modify the structure
//        return template;
//    }
//}
//public class IfDirective : Directive
//{
//    private readonly Func<bool> condition;
//    private readonly string contentToDisplay;

//    public IfDirective(Func<bool> condition, string contentToDisplay)
//    {
//        this.condition = condition;
//        this.contentToDisplay = contentToDisplay;
//    }

//    public override string ModifyStructure(string template)
//    {
//        if (condition())
//        {
//            return template.Replace("<!-- *ngIf -->", contentToDisplay);
//        }
//        else
//        {
//            return template.Replace("<!-- *ngIf -->", string.Empty);
//        }
//    }

//    public override void OnMouseEnter() { }
//    public override void OnMouseLeave() { }
//    protected override void Highlight(string color) { }
//}
//class Program
//{
//    static void Main()
//    {
//        string htmlTemplate = "<h1>{{ title }}</h1>\n<!-- *ngIf -->\n<button (click)=\"ChangeTitle('New Title')\">Change Title</button>";
//        Component appComponent = new Component("app-root", htmlTemplate, "my-app");

//        HighlightDirective highlightDirective = new HighlightDirective();
//        IfDirective ifDirective = new IfDirective(() => true, "<p>This is conditionally displayed content.</p>");
//        appComponent.AddDirective(highlightDirective);
//        appComponent.AddDirective(ifDirective);

//        // Initial render
//        appComponent.Render();

//        // Simulate button click event to change title
//        Console.WriteLine("\nButton click event:");
//        appComponent.ChangeTitle("New Title");
//    }
//}


