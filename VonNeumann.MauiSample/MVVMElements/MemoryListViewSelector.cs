namespace VonNeumann.MauiSample.Templates
{
    internal class MemoryListViewSelector: DataTemplateSelector
    {
        public DataTemplate CurrentInstruction { get; set; }
        public DataTemplate NotCurrentInstruction { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (((Instruction)item).Current)
                return CurrentInstruction;
            else
                return NotCurrentInstruction;
        }
    }
}
