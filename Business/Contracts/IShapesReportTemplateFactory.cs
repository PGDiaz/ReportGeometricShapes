namespace Business.Contracts
{
    public interface IShapesReportTemplateFactory
    {
        IShapesReportTemplate GetTemplate(string language);
    }
}
