namespace CollectionJsonFormatter.Attributes
{
    using System;

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class AddQuery : Attribute
    {
        public string Name { get; private set; }

        public AddQuery(string name)
        {
            Name = name;
        }
    }
}