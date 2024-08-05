using System;

using System;
using System.Collections.Generic;

public class Component
{
    public string Selector { get; set; }
    public string HtmlTemplate { get; set; }
    public string Title { get; set; }
    private readonly List<Directive> directives;

    public Component(string selector, string htmlTemplate, string title)
    {
        Selector = selector;
        HtmlTemplate = htmlTemplate;
        Title = title;
        directives = new List<Directive>();
    }

    public void AddDirective(Directive directive)
    {
        directives.Add(directive);
    }

    public void OnMouseEnter()
    {
        foreach (var directive in directives)
        {
            directive.OnMouseEnter();
        }
    }

    public void OnMouseLeave()
    {
        foreach (var directive in directives)
        {
            directive.OnMouseLeave();
        }
    }

    public void ChangeTitle(string newTitle)
    {
        Title = newTitle;
        Render();
    }

    public void Render()
    {
        Console.WriteLine(HtmlTemplate.Replace("{{ title }}", Title));
    }
}


public abstract class Directive
{
    public abstract void OnMouseEnter();
    public abstract void OnMouseLeave();
    protected abstract void Highlight(string color);
}
public class HighlightDirective : Directive
{
    public HighlightDirective()
    {
    }

    public override void OnMouseEnter()
    {
        Highlight("yellow");
    }

    public override void OnMouseLeave()
    {
        Highlight(null);
    }

    protected override void Highlight(string color)
    {
        if (color == null)
        {
            Console.WriteLine("Background color cleared.");
        }
        else
        {
            Console.WriteLine($"Background color set to {color}.");
        }
    }
}

class Program
{
    static void Main()
    {
        string htmlTemplate = "<h1>{{ title }}</h1>\n<button (click)=\"ChangeTitle('New Title')\">Change Title</button>";
        Component appComponent = new Component("app-root", htmlTemplate, "my-app");

        HighlightDirective highlightDirective = new HighlightDirective();
        appComponent.AddDirective(highlightDirective);

        // Initial render
        appComponent.Render();

        // Simulate mouse enter event
        Console.WriteLine("\nMouse enter event:");
        appComponent.OnMouseEnter();

        // Simulate mouse leave event
        Console.WriteLine("\nMouse leave event:");
        appComponent.OnMouseLeave();

        // Simulate button click event to change title
        Console.WriteLine("\nButton click event:");
        appComponent.ChangeTitle("New Title");
    }
}


