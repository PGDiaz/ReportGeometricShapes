using Resources.Values;

namespace Business.Contracts
{
    public interface IShapesReportTemplateFactory
    {
        IShapesReportTemplate GetTemplate(Language language);
    }
}
