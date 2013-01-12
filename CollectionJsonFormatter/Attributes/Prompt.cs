namespace CollectionJsonFormatter.Attributes
{
    using System;

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class Prompt : CollectionJsonAttribute
    {
        public string Text { get; private set; }

        public Prompt(string text)
        {
            Text = text;
        }
    }
}